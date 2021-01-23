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
    public partial class Login : Form
        {
            public Login(string accountName, string accountPassword)
            {
                InitializeComponent();
            }
    
            private void btnLogin_Click(object sender, EventArgs e)
            {
    
                using (var context = new PrincipalContext(ContextType.Domain, "Domain"))
                    {
                        using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                        {
                            foreach (var result in searcher.FindAll())
                            {
                                DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                               comboBox1.Items.Add(de.Properties["samAccountName"].Value);
                               comboBox1.Sorted = true;
                            }
                        }
                    }
     // Check if the user haven't chosen an account
       if (comboBox1.Text == "") { return; }
    
       // Check if the password TextBox is empty
       if (textBox1.Text == "") { return; }
    
       // Create a new method for checking the account and password, which returns a bool
       bool loginSuccess = CheckUserInput(comboBox1.Text.Trim(), textBox1.Text);
    
       if (loginSuccess)
       {
          // Create a new instance of your user-interface form. Give the account name and password
          // to it's constructor
          UserForm newForm = new UserForm(comboBox1.Text.Trim(), textBox1.Text.Trim()))
    
          // Show the created UserForm form
          newForm.Show();
    
          // Close this login form
          this.Close();
       }
    }
    }
