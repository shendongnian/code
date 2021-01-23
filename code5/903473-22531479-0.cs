    string userIdLogicalGetDataKey = Guid.NewGuid().ToString();
    GetUserId = () =>
    {
        var context = HttpContext.Current;
        // MVC / Web Forms
        if (context.Session != null && context.Session["UserId"] != null) {
            return (int)context.Session["UserId"];
        }
        // Web API
        return (int)CallContext.LogicalGetData(userIdLogicalGetDataKey);
    };
    public static void RegisterWebApiUserId(int userId) {
        CallContext.LogicalSetData(userIdLogicalGetDataKey, userId);
    }
