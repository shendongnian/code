      protected void Page_Load(object sender, EventArgs e)
        {
            lblUsername.Text = User.Identity.Name + "'s Profile";
            Service s = new Service();
    
            MyUser user = s.GetProfile(User.Identity.Name);
    
            try
            {
               if(user != null)
               {
                txtCountry.Text = user.Country== null? "" : user.Country.ToString();
                txtDOB.Text = user.DateOfBirth == null? "" : user.DateOfBirth.ToString();
                txtEmail.Text = user.EmailAddress== null? "" : user.EmailAddress.ToString();
                txtName.Text = user.FirstName== null? "" : user.FirstName.ToString();
                txtPassword.Text = user.Password== null? "" : user.Password.ToString();
                txtSurname.Text = user.Surname== null? "" : user.Surname.ToString();
                txtUsername.Text = user.Username== null? "" : user.Username.ToString();
              }
            }
            catch (Exception ex)
            {
                txtUsername.Text = ex.Message;
            }
        }
