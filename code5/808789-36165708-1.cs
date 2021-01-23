    public static MenuItemModel GetMenuItemFor<TController>(
        string aLinkName, string aArea, 
        Expression<Action<TController>> expression
    ) where T : Controller
    {
        var controllerName = typeof(T).Name;
        var mvcNameOfController = 
            controllerName.Substring(0, controllerName.LastIndexOf("Controller"));
        var methodName = ((MethodCallExpression)expression.Body).Method.Name;
        return new MenuItemModel(aLinkName, aArea, mvcNameOfController, methodName);
    }
