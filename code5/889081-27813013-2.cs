    public ActionResult Sample()
    {
        var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).AuthorizeAsync(cancellationToken);
        if (result.Credential != null)
        {
            var service = new AnalyticsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = result.Credential,
                ApplicationName = APPLICATION_NAME
            });
       }
    }
