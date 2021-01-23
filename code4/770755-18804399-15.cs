    public class TransactionCommandHandlerDecorator<TCommand>
        : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> decorated;
        private readonly Lazy<IUnitOfWork> lazyUnitOfWork;
        
        public TransactionCommandHandlerDecorator(
            ICommandHandler<TCommand> decorated,
            Lazy<IUnitOfWork> lazyUnitOfWork)
        {
            this.decorated = decorated;
            this.lazyUnitOfWork = lazyUnitOfWork;
        }
    
        public void Handle(TCommand command)
        {
            this.decorated.Handle(command);
    
            if (this.lazyUnitOfWork.IsValueCreated)
            {
                this.lazyUnitOfWork.Value.SubmitChanges();
            }
        }
    }
