    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using LibXmlSettings.Settings;
    using Microsoft.ApplicationBlocks.Data;
    using System.Data.Sql;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.DirectoryServices;
    using System.IO;
    using System.Linq.Expressions;
    using System.Runtime.InteropServices;
    using System.DirectoryServices.AccountManagement;
    namespace GestionnaireDesPlugins
    {
        public partial class Login : Form
        {
            public Login(string accountName, string accountPassword)
            {
                InitializeComponent();
            }
            private void LoginOnClick(object sender, EventArgs e)
            {
                if (IsValid())
                {
                    GetUser();
                    // Do whatever you want
                    ShowForm();
                }
            }
            private void GetUser()
            {
                try 
                {            
                    LdapConnection connection = new LdapConnection("AD");
                    NetworkCredential credential = new NetworkCredential(txtboxlogin.Text, txtboxpass.Text);
                    connection.Credential = credential;
                    connection.Bind();
                }
                catch (LdapException lexc)
                {
                    String error = lexc.ServerErrorMessage;
                    MessageBox.Show("error account or password.");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
            private bool IsValid()
            {
                // Check if the user haven't chosen an account
                if (!string.IsNullOrEmpty(txtboxlogin.Text) { return false; }
                // Check if the user haven't chosen an account
                if (!string.IsNullOrEmpty(txtboxpass.Text)) { return false; }
                // Check if the user haven't chosen an account
                if (!string.IsNullOrEmpty(comboBox1.Text)) { return false; }
                // Check if the password TextBox is empty
                if (!string.IsNullOrEmpty(textBox1.Text)) { return false; }
                using(PrincipalContext pc = new PrincipalContext(ContextType.Domain, "YOURDOMAIN"))
                {
                    // validate the credentials
                    bool isValid = pc.ValidateCredentials(txtboxlogin.Text, txtboxpass.Text);
                }
                return isValid;
            }
            private void ShowForm()
            {
                if (txtboxlogin.Text == "WantedAdminUser")
                {
                    using (AdminForm form2 = new AdminForm())
                       form2.ShowDialog();
                    Show(); 
                }
                else
                {
                    using (user userform = new user())
                        userform.ShowDialog();
                    Show();
                }
            }
        }
    }
