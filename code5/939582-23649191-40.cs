    public void Method1(FooViewModel input)
    {
        //duplicate code: same mapping twice, see Method2
        var domainModel = new DomainModel { Name = input.Name };
        //logic
    }
    public void Method2(FooViewModel input)
    {
        //duplicate code: same mapping twice, see Method1
        var domainModel = new DomainModel { Name = input.Name };
        //logic
    }
