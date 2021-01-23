    public class ConsoleWriter()
    {
        public static List<string> AllLines = new List<string>();
    
        public static WriteConsole(string text)
        {
            AllLines.Add(text);
            Console.Write(text);
        }
    }
