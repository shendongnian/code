    public class Question
    {
        private IConsole _console;
        private string _message;
        public class Question(IConsole console, string message)
        {
            _console = console;
        }
    }
