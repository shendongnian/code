    public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
    {
        if (controllerContext.Request.Headers.AcceptLanguage != null && 
            controllerContext.Request.Headers.AcceptLanguage.Count > 0)
        {
            string language = controllerContext.Request.Headers.AcceptLanguage.First().Value;
            var culture = CultureInfo.CreateSpecificCulture(language);
            HttpContext.Current.Items["Culture"] = culture;
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;
        }
        base.ExecuteAsync(controllerContext, cancellationToken); 
    }
