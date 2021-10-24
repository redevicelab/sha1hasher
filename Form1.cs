using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sha1hasher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length);

                foreach (byte b in hash)
                {
                    var hex = b.ToString("x2");
                    sb.Append(hex);
                }

                return sb.ToString();
            }
        }

        private void bResult_Click(object sender, EventArgs e)
        {
            string inputText = tbMac.Text;
            inputText = inputText + "\n";
            string HashSum = Hash(inputText);
            tbResult.Text = HashSum;
        }

        private void tbResult_Click(object sender, EventArgs e)
        {
            tbResult.SelectAll();
        }
    }
}
