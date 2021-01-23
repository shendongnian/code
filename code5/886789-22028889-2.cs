    public class Program
    {
        static void Main(string[] args)
        {
            (new Program()).Ask();
        }
        private void Ask()
        {
            string history = "";
            while (true)
            {
                Console.Write("Len > ");
                int len = int.Parse(Console.ReadLine());
                int[] arr = new int[len];
                for (int i = 0; i < len; i++)
                {
                    Console.Write("El{0} > ", i);
                    arr[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
                string str = string.Join(",", arr);
                Console.WriteLine("Arr > {0}", str);
                Console.WriteLine("His > {0}", history);
                history += string.Format("[{0}] ", str);
                Console.WriteLine("Again?");
                if (Console.ReadLine().Length == 0)
                    break;
                Console.WriteLine();
            }
        }
    }
