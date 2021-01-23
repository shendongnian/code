    namespace App
    {
        class Program
        {
            static Random random = new Random();
            static int[] array = { 3, 4, 6, 2, 0, 5, 11, 12, 20, 19, 18, 17, 15, 16, 1, 7, 8, 9, 10, 13, 14 };
            static List<int> results = new List<int>();
    
            static void Main(string[] args)
            {
                while (results.Count < 3)
                {
                    int num = array[random.Next(array.Length)];
                    if (!results.Contains(num))
                    {
                        results.Add(num);
                    }
                }
    
                foreach(var result in results)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
