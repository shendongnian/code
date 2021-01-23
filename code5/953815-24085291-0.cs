    void DeleteAllOrdersOfCustomer(Guid customerUID)
    {
        using (var context = new Context())
        {
           ...
           context.SaveChanges();
        }
    }
...
    using (var ts = new TransactionScope())
    {
       // call SP to delete all orders of customer 
       repoOrders.DeleteAllOrdersOfCustomer(customerUID);  // this calls a stored procedure
    
       // delete customer using EF 
       repoCustomers.DeleteCustomer(customerUID);  // throws exception due to relationship!
       ts.Complete();
    }
