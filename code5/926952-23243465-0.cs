    protected void Application_Start() 
    { 
     //Remove All View Engine including Webform and Razor
     ViewEngines.Engines.Clear();
     //Register Your Custom View Engine
     ViewEngines.Engines.Add(new CustomViewEngine());
     //Other code is removed for clarity
    } 
