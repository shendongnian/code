    [AttributeUsage(AttributeTargets.Class)]
    public class CommandClassAttribute : Attribute
    {
        readonly string commandName;
        public CommandClassAttribute(string commandName)
        {
            this.commandName = commandName;
        }
        public string CommandName
        {
            get { return commandName; }
        }
    }
