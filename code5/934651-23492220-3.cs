    public abstract class CommandProcessor
    {
        public abstract Error ProcessCommand(Command command);
    }
    public abstract class CommandProcessor<TCommand> where TCommand : Command
    {
        public override Error ProcessCommand(Command command)
        {
            if (command is TCommand == false)
                throw new ArgumentException("command should be of type TCommand");
     
            var cast = (TCommand)command;
            return this.ProcessCommand(cast);
        }
        public abstract Error ProcessCommand(TCommand command);
    }
