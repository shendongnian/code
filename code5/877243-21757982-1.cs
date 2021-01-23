    public class LoggingCommandHandlerDecorator<TCommand> 
        : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> decoratee;
        public LoggingCommandHandlerDecorator(
            ICommandHandler<TCommand> decoratee, ILog log)
        {
            this.decoratee = decoratee;
            this.log = log;
        }
        public void Handle(TCommand command)
        {
            this.log.Log("Executing " + typeof(TCommand).Name + ": " +
                JsonConvert.Serialize(command));
            try
            {
                this.decoratee.Handle(command);
            }
            catch (Exception ex)
            {
                this.log.Log(ex);
                throw;
            }
        }
    }
