    var controllerName = typeof(HistoryController).Name;
    var mvcNameOfController = 
        controllerName.Substring(0, controllerName.LastIndexOf("Controller"));
    var actionName = nameof(History.Index);
    var menuItemModel = 
        new MenuItemModel("History","Transactions", mvcNameOfController, actionName);
