    public void GetData() 
    {
        var factory1 = container.TryResolveNamed<IDbConnectionFactory>("Db_1");
        var factory2 = container.TryResolveNamed<IDbConnectionFactory>("Db_2");
        ...
    }
