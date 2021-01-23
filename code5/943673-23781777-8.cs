    public class LifetimeScopedCommandHandlerProxy<TCommand> : ICommandHandler<TCommand>
    {
        private readonly Container container;
        private readonly Func<ICommandHandler<TCommand>> decorateeFactory;
        // Here we inject the container as well.
        public LifetimeScopedCommandHandlerProxy(Container container, 
            Func<ICommandHandler<TCommand>> decorateeFactory) 
        {
            this.container = container;
            this.decorateeFactory = decorateeFactory;
        }
        public void Handle(TCommand command) {
            // Here we begin a new 'lifetime scope' before calling invoke.
            using (container.BeginLifetimeScope())
            {
                var decoratee = this.decorateeFactory.Invoke();
                decoratee.Handle(command);
            }
            // When the lifetime scope is disposed (which is what the using
            // statement does) the container will make sure that any scope
            // instances are disposed.
        }
    }
