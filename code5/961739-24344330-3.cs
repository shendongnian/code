    // compiled query
    static Func<NorthwindDataContext, int, IQueryable<Order>> GetOrderById =
        CompiledQuery.Compile((NorthwindDataContext db, int orderId) => LINQ GOES HERE );
     
     
    static void Warmup() 
    {
        var context = new NorthwindDataContext("ConnectionString");
        // dispose the connection to force the attempted database call to fail
        context.Connecction.Dispose(); 
        try  
        {
             GetOrderById(context, 1);
        }
        catch (Exception ex)
        {
             // we expect to find InvalidOperationException with the message
             // "The ConnectionString property has not been initialized."
             // but the underlying query will now be compiled
        }
    }
    
    static void GetData() 
    {
         // as long as we called warmup first, this will not take the compilation performance hit
         var context = new NorthwindDataContext("ConnectionString");
         var result = GetOrderById(context, 1);
    }
