     protected void btnLogin_Click(object sender, EventArgs e)
            {
                AccountBLL accBLL = new AccountBLL();
        
                string username = tbUsername.Text;
                string password = accBLL.getAccount(username).Password;
                if(password != null)
        {
                if (tbPassword.Text == password)
                {
                    // Authenticate user
                    string role = accBLL.getAccount(username).Role;
        
                    // Create Form Authentication Ticket
                  ..... your remaining code including else
        
        }
        else 
        {
        lblMsg.Text = "Account Doesnt Exist";
        }
