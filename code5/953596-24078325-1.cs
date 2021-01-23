    struct ConsoleStruct
    {
        private string _text;
        public ConsoleStruct(string text)
        {
            _text = text;
        }
        public void WriteLine(string txt)
        {
            Console.WriteLine(_text);
        }
    }
    class Program
    {
        private static ConsoleStruct Console = new ConsoleStruct("B A C");
        static void Main(string[] args)
        {
            Console.WriteLine("A");
        }
    }
