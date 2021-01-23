    Driver IDriverService.New()
    {
       return New(); // Calls the method below
    }
    
    public SubclassOfDriver New()
    {
       return new SubclassOfDriver();
    }
