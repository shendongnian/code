    [WebMethod(EnableSession = true)]
    [ScriptMethod]
    public static string populateModels(string[] makeIds)
    {
        // Check if value is in Session
        if(HttpContext.Current.Session["SuperSecret"] != null)
        {
            // Getting the value out of Session
            var superSecretValue = HttpContext.Current.Session["SuperSecret"].ToString();
        }
        // Storing the value in Session
        HttpContext.Current.Session["SuperSecret"] = mySuperSecretValue;
    }
