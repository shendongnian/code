     public void checklogin(string user, string pass)
        {
            if (user== "123" && pass == "123")
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
