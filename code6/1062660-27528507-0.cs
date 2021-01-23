    public class OrderDataService : EntityFrameworkDataService<ObjectContext>
    {
        protected override ObjectContext CreateDataSource()
        {
            IObjectContextAdapter context = new OrderContext();
            return context.ObjectContext;
        }
    } 
