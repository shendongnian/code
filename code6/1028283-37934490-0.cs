    [assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AppConfig), "Configure")]
    public static class AppConfig
    {
        public static void Configure()
        {
            var settings = new NameValueCollection();
            settings.Add("defaultUrl", "~/Account/Default.aspx");
            settings.Add("loginUrl", "~/Default.aspx");
            settings.Add("timeout", "10");
            FormsAuthentication.EnableFormsAuthentication(settings);
        }
    }
