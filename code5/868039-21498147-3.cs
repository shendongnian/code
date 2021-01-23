    private void btn_Click(object sender, RoutedEventArgs e)
    {
       string DatabaseId = "99999999999999999999";
       string UserName = "user";
       string Password = "pass";
       
       string script = string.Format("login({0}, {1}, {2});", DatabaseId, UserName, Password);
    
       ScriptManager
    	.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "login", script, true);
    }
