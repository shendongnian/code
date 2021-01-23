    public class SalesInsertCommandHandler<TCommand> : ICommandHandler<TCommand>
    {
        public SalesInsertCommandHandler(IUnitOfWork<SalesConnection> unitOfWork)
        {
        }
    }
