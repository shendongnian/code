    public interface IUserInput
    {
        string ReadInput();
    }
    public class ConsoleInput : IUserInput
    {
        public ReadInput()
        {
            return Console.ReadLine();
        }
    }
    public class YourClass
    {
        IUserInput _userInput;
        // Can inject TEST or REAL input
        public YourClass(IUserInput userInput)
        {
            _userInput = userInput;
        }
        // ... Your code
        public void YourMethod()
        {
            var doSomething = _userInput.ReadInput();
        }
    }
