        void Page_PreRender(object sender, EventArgs e)
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if (currentUser != null && currentUser.IsOnline)
                this.lblLoggedUser.Text = currentUser.UserName;
            else
                this.lblLoggedUser.Text = "not authenticated";
        }
