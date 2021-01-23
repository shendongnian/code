    public List<YourReturnType> GetEverything()
    {
       using (var yourDbcontext = new YourContext()
       {
           yourDbcontext.Configuration.LazyLoadingEnabled = false;
           return GetAll.Include(...).ToList();
       }
    
    }
