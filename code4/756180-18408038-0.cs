    [WebMethod(EnableSession = true)]
    [ScriptMethod]
    public static string populateModels(string[] makeIds)
    {
        // Check if value is in Session
        if(Session["SuperSecret"] != null)
        {
            // Getting the value out of Session
            var superSecretValue = Session["SuperSecret"].ToString();
        }
        // Storing the value in Session
        Session["SuperSecret"] = mySuperSecretValue;
    }
