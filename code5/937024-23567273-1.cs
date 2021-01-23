    // This interface is defined in a core application layer
    public interface ICommandDispatcher
    {
        void Execute(ICommand command);
    }
    // This class is defined in your Composition Root (where you wire your container)
    // It needs a dependency to the container.
    sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly Container container;
        public CommandDispatcher(Container container) {
            this.container = container;
        }
        public void Execute(ICommand command) {
            var handlerType = typeof(ICommandHandler<>)
                .MakeGenericType(command.GetType());
            dynamic handler = container.GetInstance(handlerType);
            handler.Handle((dynamic)command);
        }
    }
