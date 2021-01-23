    public static void SetWelcomePage(Web web,string pageUrl)
    {
        var ctx = web.Context;
        var rootFolder = web.RootFolder; 
        rootFolder.WelcomePage = pageUrl;
        rootFolder.Update();
        ctx.ExecuteQuery();
    }
