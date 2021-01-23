    public class InsertCommandHandler : InsertCommandHandler<Order>
    {
        public InsertCommandHandler(IUnitOfWork<SalesDbContext> salesUnitOfWork)
        {
            // ...
        }
    }
