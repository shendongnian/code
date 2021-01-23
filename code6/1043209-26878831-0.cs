    void OnLoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
    {
        DateTime loginTime=DateTime.Now;
        if (loginTime.Hour >= 9 && loginTime.Hour <= 17)
                    //log in your user
                else
                    //show error message about time
    }
