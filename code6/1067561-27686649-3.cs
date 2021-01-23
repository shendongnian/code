    protected void Application_Start()
    {
       ...
       ModelBinders.Binders.Add(typeof(DateTime), new DateFormatBinding());
       ModelBinders.Binders.Add(typeof(DateTime?), new DateFormatBinding());
       ...
    }
