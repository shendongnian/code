    void Application_PostAuthorizeRequest(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.HttpMethod != "POST") return;
        String key = String.Concat(HttpContext.Current.Request.Path, "::", HttpContext.Current.Request.Form["__EVENTTARGET"]);
        String message;
        if (!auditMap.TryGetValue(key, out message) return;
        auditService.LogEvent(message);
        // Can also pass HttpContext.Current.User.Identity.Name into a format string, etc.
    }
