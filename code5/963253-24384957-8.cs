    public class InsertCommandHandler : ICommandHandler<Order>
    {
        public InsertCommandHandler(IUnitOfWork<SalesConnection> salesUnitOfWork)
        {
            // ...
        }
    }
