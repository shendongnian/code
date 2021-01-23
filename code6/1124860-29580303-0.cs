    public Task<Customer> FindAsync(params object[] keyValues)
    {
        using (var nw = new NWRepository())
        {
            return nw.DoSomethingAsync<Customer>(keyValues)
        }
    }
