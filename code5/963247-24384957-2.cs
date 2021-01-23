    public class InsertCommandHandler : InsertCommandHandler<Order>
    {
        public InsertCommandHandler(IUnitOfWork<SalesConnection> salesUnitOfWork)
        {
            // ...
        }
    }
