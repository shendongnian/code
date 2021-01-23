    GetUserId = () =>
    {
        var context = HttpContext.Current;
        // MVC / Web Forms
        if (context.Session != null && context.Session["UserId"] != null) {
            return (int)context.Session["UserId"];
        }
        // Web API
        return (int)CallContext.LogicalGetData("__userId");
    };
    public static void RegisterWebApiUserId(int userId) {
        CallContext.LogicalSetData("__userId", userId);
    }
