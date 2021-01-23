    [CommandTypeAttribute(typeof(StartCommand))]
    public class StartCommandHandler : ICommandHandler
    {
        public StartCommandHandler()
        {
        }
        public void Execute(ICommand data)
        {
            StartCommand scData = data as StartCommand;
            if (scData == null)
                throw new ArgumentException(string.Format("Invalid command for CommandHandler 'StartCommandHandler'. Expecting 'StartCommand' but received {0}", data == null ? "null" : data.GetType().Name));
            //start command execution
        }
    }
