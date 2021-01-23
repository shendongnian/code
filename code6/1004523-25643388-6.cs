    protected void Application_AcquireRequestState(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session != null)
        {
            string name = (CultureInfo)this.Session["Culture"];
            if (!String.IsNullOrEmpty(name))
            {
                CultureInfo ci = new CultureInfo(name );
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture =
                    CultureInfo.CreateSpecificCulture(ci.Name);
            }
        }
    }
