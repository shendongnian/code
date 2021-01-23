     public void checklogin()
        {
            UserLoginForm uform = new UserLoginForm();
            if (uform.userID == "123" && uform.userPASS == "123")
            {
                MessageBox.Show("Welcome to the bank");
                AccountForm aform = new AccountForm();
                aform.Show();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
