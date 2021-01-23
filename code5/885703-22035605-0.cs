    var ctx = new PrincipalContext(ContextType.Domain);
    var queryCtx = ctx.GetType().GetProperty("QueryCtx", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(ctx, null);
    var ctxBase = (DirectoryEntry)queryCtx.GetType().GetField("ctxBase", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(queryCtx);
    var srch = new DirectorySearcher(ctxBase);
    srch.Filter = "(objectSid=S-1-5-21-.......)";
    var result = srch.FindOne().GetDirectoryEntry();
    var adUtils = queryCtx.GetType().Assembly.GetType("System.DirectoryServices.AccountManagement.ADUtils");
    var up = (UserPrincipal)adUtils.GetMethod("DirectoryEntryAsPrincipal", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, new object[] { result, queryCtx });
