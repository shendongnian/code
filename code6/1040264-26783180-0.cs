    class Program
    {
        delegate void writeDelegate(string format, params object[] arg);
        static void Main(string[] args)
        {
            writeDelegate write = Console.WriteLine;
            write("Simple text.");
            write("Formatted {0}: {1}", "text", 10);
            Console.ReadKey();
        }
    }
