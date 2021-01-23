    public async Task<List<CustomerEmail>> GetCustomerDropDownList()
    {
        try
        {
            using (YeagerTechEntities DbContext = new YeagerTechEntities())
            {
                DbContext.Configuration.ProxyCreationEnabled = false;
                DbContext.Database.Connection.Open();
                var customers = await DbContext.Customers.Select(s =>
                new CustomerEmail()
                {
                    CustomerID = s.CustomerID,
                    Email = s.Email
                }).ToListAsync();
                return customers;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
