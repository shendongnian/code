    class Program
    {
        static void Main(string[] args)
        {
            var color = ColorType.Red;
            Console.WriteLine(color.HasFlags(ColorType.Red)); // true;
            Console.WriteLine(color.HasFlags(ColorType.Red, ColorType.Blue)); // false;
            color = ColorType.All;
            Console.WriteLine(color.HasFlags(ColorType.Red, ColorType.Blue)); // true;
            
            Console.ReadLine();
        }
    }
