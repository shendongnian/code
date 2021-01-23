    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Security.Cryptography.X509Certificates;
    using System.Net.Security;
    using System.Net;
    namespace WCFClientApplication
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string _name = "";
        private string _passwd = "";
        private string _domain = "";
        public string UserName
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Password
        {
            get { return _passwd; }
            set { _passwd = value; }
        }
        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(usrTxt.Text) || !String.IsNullOrEmpty(passTxt.Text) || !String.IsNullOrEmpty(domainTxt.Text))
            //{
                UserName = usrTxt.Text;
                Password = passTxt.Text;
                Domain = domainTxt.Text;
                WCFTestApplication.WCFTestApplicationClient client = new WCFTestApplication.WCFTestApplicationClient();
                
                client.ClientCredentials.Windows.ClientCredential.Domain = Domain;
                client.ClientCredentials.Windows.ClientCredential.UserName = UserName;
                client.ClientCredentials.Windows.ClientCredential.Password = Password;
                //this part needs to be modified, so certificate can be accepted from other machines as well. 
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
                textBox1.Text = client.GetData();
                client.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Fields like username, password and domain must not be blank...!","Warning...!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
        private void domainTxt_MouseHover(object sender, EventArgs e)
        {
            tipLbl.Visible = true;
        }
        private void domainTxt_MouseLeave(object sender, EventArgs e)
        {
            tipLbl.Visible = false;
        }
        }
    }
