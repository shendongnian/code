    public void UpdateCustomer (Csutomer customer)
    {
        using (var ctx = new Context())
        {
            ctx.Customer.ApplyChanges(customer);
            ctx.SaveChanges(); // 
        }            
    }
