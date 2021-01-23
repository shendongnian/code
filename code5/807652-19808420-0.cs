        protected void btLogin_Click(object sender, EventArgs e)
        {
            if (check(txtPass.Text) && check(txtUser.Text))
            {
                var user = new UserManager().login(txtUser.Text, txtPass.Text);
                if (user != null)
                {
                    // this is the test you're looking for, the rest is only context
                    if (!FileManager.alreadyLoggedIn(user.email))
                    {
                        FormsAuthentication.SetAuthCookie(user.email, false);
                    }
                    else
                    {
                        //throw error that it is already connected in some other place
                    }
                }
                else
                {
                        //throw error that login details are not OK
                }
            }
        }
