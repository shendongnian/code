    class Program
    {
        static void Main(string[] args)
        {
            int i = int.MaxValue;
            try
            {
                checked
                {
                    i += 1;
                }
                Console.WriteLine(i);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Overflow!");
            }
        }
    }
