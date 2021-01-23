    protected void Application_Start(){
        Database.SetInitializer<SchoolContext>(new SchoolInitializer());
        AreaRegisration.RegisterAllAreas();
        ...
    }
