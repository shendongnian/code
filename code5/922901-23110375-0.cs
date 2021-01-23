           MyLoginService.LoginServiceClient LoginClient=  new MyLoginService.LoginServiceClient();
               {
                LoginClient.ValidateUsersCompleted  += (a, ae) =>
                {
                   if(ae.Error == null)
                   {
                   if(ae.Result != null)
                   {
                    if(ae.Result == 1)
                        {
                         MessageBox.Show("Logged in successfully");
                        }
                        else if (ae.Result <= 0)
                        {
                        MessageBox.Show("Incorrect Username or Password");
                        }
                    }
                  }
                  else
                  {
                        MessageBox.Show("Error occured from service");
                  } 
                };
                LoginClient.ValidateUsers(uname.Text, pass.Password);
            }
           
