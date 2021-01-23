            Bank.Client.ServicesName.User user = new Bank.Client.ServicesName.User();
            user.Username = txtusername.Text;
            user.Password = txtpassword.Text;
            user.Active = true;
            bool result = client.addNewUser(user);
