            protected void login_Click(object sender, EventArgs e)
        {
            var user = UserService.Authenticate(username.Text, password.Text);
            if (user != null)
            {
                message.InnerHtml = String.Format("Welcome {0}", user.Name);
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Response.Redirect(ContentHelper.ResolveUrl(Content, false), false);
            }
            else
            {
                message.InnerHtml = "Incorrect username and password";
            }
        }
