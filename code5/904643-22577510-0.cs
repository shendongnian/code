    public class GenericDecorator<TCommand> : ICommandHandler<TCommand> {
        public GenericDecorator(
            ICommandHandler<TCommand> decoratee,
            ICommandHandler<LoggingCommand> dependency)
        {
        }
    }
