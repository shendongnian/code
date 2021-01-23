    protected void Application_Start()
    {
       ViewEngines.Engines.Clear();
       ViewEngines.Engines.Add(new RazorViewEngine());
       // Other code
    }
