        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            var manager = HttpContext.Current.GetOwinContext();
            ApplicationUser u = new ApplicationUser() { UserName = userName };
            var userMangager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
            IdentityResult result = userMangager.Create(u, Password.Text);
            if (result.Succeeded) 
            {
                manager.Authentication.SignIn();
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
