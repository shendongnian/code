    public interface ICommandHandler
    {
       bool CanHandle(ICommand command);
       void Handle(ICommand command);
    }
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler
      where TCommand : ICommand
    {
      public bool CanHandle(ICommand command) { return command is TCommand; }
      public void Handle(ICommand command) 
      {
        var typedCommand = command as TCommand;
        if (typedCommand == null) throw new InvalidCommandTypeException(command);
        Handle(typedCommand);
      }
      protected abstract void Handle(TCommand typedCommand);
    }
