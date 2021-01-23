            if (l_oDr.HasRows)
            {
                while(l_oDr.Read())
                {
                   string ID, Password;
                   ID = l_oDr.GetValue(0).ToString().Trim();
                   Password = l_oDr.GetValue(1).ToString().Trim();
                   if (ID == txt_userid.Text && Password == txt_password.Text)
                   {
                      count = count + 1;
                      StRegistration strpage = new StRegistration();
                      this.NavigationService.Navigate(strpage);
                   }
               }
            }
