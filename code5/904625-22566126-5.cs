	public class MessageLogger<TCommand> : ICommandHandler<TCommand>
		where TCommand : MessageCommand
	{
		private ICommandHandler<TCommand> innerHandler;
		private LoggerProxy logger;
		public MessageLogger(
			ICommandHandler<TCommand> innerHandler,
			LoggerProxy logger)
		{
			this.innerHandler = innerHandler;
			this.logger = logger;
		}
		public void Execute(TCommand command)
		{
			innerHandler.Execute(command);
			var logCommand = new LogCommand
			{
				LogMessage = command.Message,
				Time = DateTime.Now
			};
			logger.Execute(logCommand);
		}
	}
