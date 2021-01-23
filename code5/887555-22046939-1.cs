    public class Consumer
    {
        private ICommandService _commandInfo;
        public Consumer(ICommandService commandInfo)
        {
            _commandInfo = commandInfo;
        }
        public void DoSomething()
        {
            _commandInfo.Execute();
        }
    }
