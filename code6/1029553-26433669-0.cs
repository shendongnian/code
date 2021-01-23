    public class CommandLifetimeScopeDecorator<T> : ICommandHandler<T>
        {
            private readonly Func<ICommandHandler<T>> _handlerFactory;
            private readonly Container _container;
    
            public CommandLifetimeScopeDecorator(
            Func<ICommandHandler<T>> handlerFactory, Container container)
            {
                _handlerFactory = handlerFactory;
                _container = container;
            }
    
            public void Handle(T command)
            {
                using (_container.BeginLifetimeScope())
                {
                    var handler = _handlerFactory(); // resolve scoped dependencies
                    handler.Handle(command);
                }
            }
    
        }
    
        public interface ICommandHandler<in T>
        {
            void Handle(T command);
        }
