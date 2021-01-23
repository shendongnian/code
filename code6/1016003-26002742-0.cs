    protected override void InitializeCulture()
        {
            
            HttpCookie cookie = Request.Cookies["CurrentLanguage"];
            if (!IsPostBack && cookie != null && cookie.Value != null)
            {
                if (cookie.Value.ToString() == "en-CA")
                {
                   // currently english
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-CA");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-CA");
                    base.InitializeCulture();
                }
                else
                {
                   //currently french
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-CA");
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-CA");
                    base.InitializeCulture();
                }
            }
        }
