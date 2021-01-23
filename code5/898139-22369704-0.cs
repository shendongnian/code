    class Program
    {
        static void Main()
        {
            var numbers = String.Empty;
            for (int i = 100; i >= 0l; i--)
            {
                numbers += i.ToString() + " ";
                if ((i % 10) == 0)
                {
                    Console.WriteLine(numbers);   
                    numbers = String.Empty;
                }
            }
        }
    }
