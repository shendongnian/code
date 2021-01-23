    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 10, 5, 10, 2, 2, 3, 4, 5, 5, 6, 7, 8, 9, 11, 12, 12 };
            for (int i = 0; i < array.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                        count = count + 1;
                }
                Console.WriteLine("\t\n " + array[i] + " occurs " + count + " times");
            }
            Console.ReadKey();
        }
    }
