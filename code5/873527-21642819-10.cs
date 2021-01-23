        protected void LogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();
    //if you want to redirect to your desired page just use following line instead of RedirectToLoginPage
    //Response.Redirect("myPage.aspx");
        }
