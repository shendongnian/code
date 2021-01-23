    public void NewData(AbstractBaseClass abs)
    {
        ID = abs.ID;
        var results= abs.listOfResults();
        var something= abs.GetSomething();
        abs.DoSomething();
    }
