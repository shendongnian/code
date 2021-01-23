    class Program
    {
        static void Main()
        {
            char input;
            do
            {
                input = char.ToUpperInvariant(Console.ReadKey().KeyChar);
            } while (input != 'R');
        }
    }
