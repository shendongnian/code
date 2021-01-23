    public class InsertCommandHandler : ICommandHandler<Order>
    {
        public InsertCommandHandler(IUnitOfWork<SalesDbContext> salesUnitOfWork)
        {
            // ...
        }
    }
