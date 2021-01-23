    namespace TestConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] A = new int[12] {2,3,-5,-67,23,-4,243,-23,2,-45,56,-9};
                var result = from r in
                             A.Where(GetOdd)
                             select r;
                var total2 = result.Sum();
                int i = 0;
                foreach (var r in result)
                {
                   Console.WriteLine("index: {0}  value: {1} total: {2}", i, r, total2);
                   i++;
                }
                Console.ReadKey(true);
            }
            static bool GetOdd(int number)
            {
                if (number % 2 != 0)
                    return true;
                else
                    return false; 
            }
        }
    }
