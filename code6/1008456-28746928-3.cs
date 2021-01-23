    public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext context, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
    {
            var owinContext = context.Request.GetOwinContext();
            var owinEnvVars = owinContext.Environment;
            var appName = owinEnvVars["AppName"];
    }
