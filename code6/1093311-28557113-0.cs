    var actual = this.ResponseMock
        .GetArgumentsForCallsMadeOn(r => 
            r.RedirectToRoute(new { Controller = "dummy", Action = "dummy" }),
                options => options.IgnoreArguments())[0][0];
    var controllerProperty = properties.Find("Controller", false);
    var actionProperty = properties.Find("Action", false);
    var controllerProperty = properties.Find("Controller", false);
    var actionProperty = properties.Find("Action", false);
    string controllerValue = controllerProperty.GetValue(actual).ToString();
    string actionValue = actionProperty.GetValue(actual).ToString();
