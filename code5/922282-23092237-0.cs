    protected override void OnPreInit(EventArgs e)
    {
        if (Page.IsPostBack)
        {
            if (Request.Form["__EVENTTARGET"] == "Lnk_cultChange")
            {
                if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en")
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                    base.InitializeCulture();
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    base.InitializeCulture();
                }
            }
        
        }
        
        base.OnPreInit(e);
    }
