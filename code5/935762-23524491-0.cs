    //method that returns a value
    public int Ping()
    {
        return Protect(c => c.Ping());
    }    
    
    //void method usage
    public void Nothing(int stuff)
    {
        Protect(c => c.Nothing(stuff));
    }      
