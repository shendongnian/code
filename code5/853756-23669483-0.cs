    {
        base.InitializeCulture();
        System.Threading.Thread.CurrentThread.CurrentCulture = new   System.Globalization.CultureInfo(Session["Culture"].ToString());
        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Session["Culture"].ToString());
 
    }
}
