    [DbFunction("MyContext", "CustomersByZipCode")]
    public IQueryable<Customer> CustomersByZipCode(string zipCode)
    {
        var zipCodeParameter = zipCode != null ?
            new ObjectParameter("ZipCode", zipCode) :
            new ObjectParameter("ZipCode", typeof(string));
 
        return ((IObjectContextAdapter)this).ObjectContext
            .CreateQuery<Customer>(
                string.Format("[{0}].{1}", GetType().Name, 
                    "[CustomersByZipCode](@ZipCode)"), zipCodeParameter);
    }
