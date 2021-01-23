    public interface IConsole
    {
        ConsoleKeyInfo ReadKey();
        void WriteLine(String line);
    }
    public interface IConsoleContext
    {
        void Run(Action<IConsole> main);
    }
