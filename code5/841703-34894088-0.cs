    class Program
    {
        static void Main(string[] args)
        {              
            int[] array = { 10, 5, 10, 2, 2, 3, 4, 5, 5, 6, 7, 8, 9, 11, 12, 12 };
            int count = 1;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i; j < array.Length - 1 ; j++)
                {
                   if(array[i] == array[j+1])
                      count = count + 1;
                }
                Console.WriteLine("\t\n " + array[i] + "occurse" + count);
                Console.ReadKey();
            }
        }
    }
