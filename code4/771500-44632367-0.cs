    protected void Session_Start(Object sender, EventArgs e)
    {
        Session["sessionId"] = Session.SessionID;
        Session.Timeout = 120;
        //first point of request, get the user's browser language
        string[] languages = Request.UserLanguages;
        if (languages != null && Session.IsNewSession)
        {
            LanguageEnum requestLanguage = LanguageHelper.GetLanguage(languages);
            if (requestLanguage != LanguageEnum.NL)//NL is default for the sources
            {
                Response.RedirectToRoute("Locolized", new { lang = requestLanguage.ToString().ToLower() });//Locolized is an route name, see below
            }
        }
    }
