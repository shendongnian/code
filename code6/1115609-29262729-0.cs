    public class CustomdbContext : DbContext
    {       
        public IQueryable<TEntity> ApplyCustomerFilter<TEntity>(IQueryable<TEntity> query) where TEntity : Customer 
        {
             return query.Where(x => x.CustomerId == customerctxId);
        }
    }
