    public IEnumerable<Foo> GetValidCustomers() 
    {
        var customers = _database.GetCustomers();
        return this.FilterToValidCustomers(customers);
    }
    private IEnumerable<Foo> FilterToValidCustomers(IEnumerable<Foo> customers) 
    {
        //crazy complex logic here 
    }
