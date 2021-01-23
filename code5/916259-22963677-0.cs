    private void btnLogin_Click(object sender, EventArgs e)
            {
    
                try
                {
                    LdapConnection connection = new LdapConnection("AD");
                    NetworkCredential credential = new NetworkCredential(txtboxlogin.Text, txtboxpass.Text);
                    connection.Credential = credential;
                    connection.Bind();
                   
                   MessageBox.Show("You are log in");
                   Hide();
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
                catch (LdapException lexc)
                {
                    String error = lexc.ServerErrorMessage;
                    MessageBox.Show("error account or password.");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(Convert.ToString(exc));
                }
