		public class ValidationCommandHandlerDecorator<TCommand, TResult>
			: ICommandHandler<TCommand, TResult>
			where TCommand : ICommand<TResult>
		{
			private readonly ICommandHandler<TCommand, TResult> decorated;
		 
			public ValidationCommandHandlerDecorator(ICommandHandler<TCommand, TResult> decorated)
			{
				this.decorated = decorated;
			}
		 
			[DebuggerStepThrough]
			public TResult Handle(TCommand command)
			{
				var validationContext = new ValidationContext(command, null, null);
				Validator.ValidateObject(command, validationContext, validateAllProperties: true);
				return this.decorated.Handle(command);
			}
		}
