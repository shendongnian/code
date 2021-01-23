    protected void Application_Start()
    {
        ...
 
        GlobalFilters.Filters.Add(new SecurityQuestionCompleteFilter());
    
        ...
    }
