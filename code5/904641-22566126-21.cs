    public class CommandHandlerMediator<TCommand>
    {
        private readonly ICommandHandler<TCommand> handler;
        public CommandHandlerMediator(ICommandHandler<TCommand> handler)
        {
            this.handler = handler;
        }
        public void Execute(TCommand command)
        {
            this.handler.Execute(command);
        }
    }
