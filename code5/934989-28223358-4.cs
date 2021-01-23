    protected void Application_Start()
    {
        ...
        System.Web.Mvc.ModelBinders.Binders.Add(typeof(DTParameterModel), new DTModelBinder());
    }
