    public interface IUserInput
    {
        string ReadLine();
    }
    
    public class ConsoleInput : IUserInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
    
    public class MockInput : IUserInput
    {
        // or you could open the file, and read it line by line, each time ReadLine is called
        public string ReadLine()
        {
            return "Hello";
        }
    }
    
    public class MyObject
    {
        private IUserInput _userInput;
    
        public MyObject(IUserInput userInput)
        {
            _userInput = userInput;
        }
    
        public void DoStuff()
        {
            Console.WriteLine(_userInput.ReadLine());
        }
    }
    // somewhere else, for live code:
    MyObject obj = new MyObject(new ConsoleInput());
    obj.DoStuff();
    // or for test code:
    MyObject obj = new MyObject(new MockInput());
    obj.DoStuff();
