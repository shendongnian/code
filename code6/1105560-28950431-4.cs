    public class Program
    {
        static void Main(string[] args)
        {
            var str = new ColoredString()
            {
                Color = ConsoleColor.Cyan,
                Content = "abcdef",
            };
            PrintColor(str);
            Console.ReadKey(false);
        }
        public static void PrintColor(ColoredString str)
        {
            var prevColor = Console.BackgroundColor;
            Console.BackgroundColor = str.Color;
            Console.Write(str.Content);
            Console.BackgroundColor = prevColor;
        }
    }
    public class ColoredString
    {
        public ConsoleColor Color { get; set; }
        public string Content { get; set; }
    }
