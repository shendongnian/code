    public void NewData(ICanDoSomething con)
    {
        ID = con.ID;
        var results = con.ListOfResults();
        var something = con.GetSomething();
        ...
    }
