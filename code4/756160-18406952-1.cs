    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ...
            IAccountBL accountBL = ...
            config.Filters.Add(new CustomAuthorizationFilter(accountBL));
        }
    }
