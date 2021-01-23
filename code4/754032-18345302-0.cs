    using System;
    
    delegate void CommandHandler<TCommand>(TCommand command)
        where TCommand : ICommand;
    delegate void ICommandHandler(ICommand command);
    
    interface ICommand {}
    
    class Command : ICommand {}
    
    class Test
    {
        public static void Main()
        {
            ICommandHandler x = null;
            CommandHandler<Command> y = new CommandHandler<Command>(x);
        }
    }
