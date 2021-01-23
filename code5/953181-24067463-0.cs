    var url = GetUrlStringStringObjectArray = (string actionName, string controllerName, RouteValueDictionary parameters) => {
        Assert.AreEqual<string>(EventsController.Actions.Register.ToString(), actionName, "Url.Action called with an incorrect action.");
        Assert.AreEqual<string>(EventsController.ControllerName, controllerName, "Url.Action called with an incorrect controller.");
        string id = parameters["id"].ToString();
        if (!String.IsNullOrWhiteSpace(id)) 
            return String.Format("/{0}/{1}/{2}", controllerName, actionName, id);
        else
            return String.Format("/{0}/{1}", controllerName, actionName);
    }
