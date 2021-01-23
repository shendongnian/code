    public async Task<MyEnvelope<Customer>> FindAsync(params object[] keyValues)
    {
        using (var nw = new NWRepository())
        {
             Customer c = await  nw.FindAsync<Customer>(keyValues);
              return new MyEnvelope<Customer>(c);
        }
     }
