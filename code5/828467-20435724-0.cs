    internal void CompleteRequest() {
      this._requestCompleted = true;
      if (HttpRuntime.UseIntegratedPipeline) {
        HttpContext context = this._application.Context;
        if (context != null && context.NotificationContext != null) {
          context.NotificationContext.RequestCompleted = true;
        }
      }
    }
