    protected void Application_BeginRequest()
    {
        // specify any culture you want
        System.Globalization.CultureInfo cInf = new System.Globalization.CultureInfo("ru-RU", false);
        System.Threading.Thread.CurrentThread.CurrentCulture = cInf;
        System.Threading.Thread.CurrentThread.CurrentUICulture = cInf;
    }
