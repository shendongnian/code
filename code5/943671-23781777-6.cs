    public class LifetimeScopedCommandHandlerProxy<TCommand> : ICommandHandler<TCommand>
    {
        private readonly Func<ICommandHandler<TCommand>> decorateeFactory;
        public LifetimeScopedCommandHandlerProxy(
            Func<ICommandHandler<TCommand>> decorateeFactory) {
            this.decorateeFactory = decorateeFactory;
        }
        public void Handle(TCommand command) {
            var decoratee = this.decorateeFactory.Invoke();
            decoratee.Handle(command);
        }
    }
