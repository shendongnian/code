    public IEnumerable<Customer> GetCustomers(int pageSize, int pageNumber)
    {
        var query = from c in customers
                    select c;
        
        return query.Skip(pageSize * pageNumber)
                    .Take(pageSize)
                    .ToList();
    }
