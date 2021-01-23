    public class LoggingHandler : ICommandHandler<MessageCommand>
    {
        private ICommandHandler<MessageCommand> innerHandler;
    
        public LoggingHandler(ICommandHandler<MessageCommand> innerHandler)
        {
            this.innerHandler = innerHandler;
        }
    
        public void Execute(MessageCommand command)
        {
            innerHandler.Execute(command);
    
            Debug.WriteLine(string.Format("Message \"{0}\" sent at {1}",
            command.Message, DateTime.Now));
        }
    }
