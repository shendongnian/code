    public void NewData(ICanGetSomething con)
    {
        ID = con.ID;
        var results = con.ListOfResults();
        var something = con.GetSomething();
        ...
    }
