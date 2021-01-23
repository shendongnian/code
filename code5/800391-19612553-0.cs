    public static void LoginFirstTime(string Email, string Password)
    {
        //This method logs the user in for the first time after he has registered.
        HttpContext.Current.Response.Redirect("UserPage.aspx", true);
        //After logging in, the user will be redirected to his personal page.
    }
