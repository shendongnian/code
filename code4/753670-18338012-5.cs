    public NewData2(Concrete con)
    {
        ID = con.ID;
        var results= con.listOfResults();
        var something= con.GetSomething();
        Something = new List<Somethings>();
        con.DoSomething();
    }
