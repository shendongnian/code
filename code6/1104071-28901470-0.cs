    public List<IAccount> FilterAccounts( Predicate<IAccount> condition )
    {    
        return AccountList.Where(a => condition(a) && a.SomeBoolMethod() && a.SomeOtherBoolMethod() )
    }
    
    public List<IAccount> IsGreater(DateTime someDate)
    {    
        return FilterAccounts( a => a.AccountDate >= someDate );
    }
    
    public List<IAccount> IsLess(DateTime someDate)
    {    
        return FilterAccounts( a => a.AccountDate < someDate );
    }
