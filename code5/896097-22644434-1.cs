    public List<User> GetUsersByLocation(string schema, int locationId)
    {
        var interceptor = new ChangeSchemaNameCommandInterceptor(schema);
        try
        {
            DbInterception.Add(interceptor);
            return .... // (your EF LINQ query)
        }
        finally
        {
            DbInterception.Remove(interceptor);
        }
        
    }
