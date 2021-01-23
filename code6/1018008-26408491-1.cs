    private static void WebApiConfig(IAppBuilder app)
    {
        var webApiConfig = new HttpConfiguration();
        webApiConfig.SuppressDefaultHostAuthentication();
        // Web API filters
        webApiConfig.Filters.Add(new DbEntityValidationExceptionAttribute());
        webApiConfig.Filters.Add(new DeleteConflictsWithReferenceConstraintExceptionAttribute());
    }
