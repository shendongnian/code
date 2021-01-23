    public abstract class CommandHandler<TConnection, TCommand> :
         ICommandHandler<TCommand>
        where TConnection : IConnection
    {
        private readonly IUnitOfWork<TConnection> unitOfWork;
        public CommandHandler(IUnitOfWork<TConnection> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
    public class SalesInsertCommandHandler<TCommand> : 
        CommandHandler<SalesConnection, TCommand>
    {
    }
