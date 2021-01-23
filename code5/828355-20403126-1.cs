    public class Program
    {
        static void Main(string[] args)
        {
            int size1, size2;
            while (true)
            {
                Console.Write("Size of list #1: ");
                int.TryParse(Console.ReadLine(), out size1);
                if (size1 <= 0)
                    break;
                Console.Write("Size of list #2: ");
                int.TryParse(Console.ReadLine(), out size2);
                if (size2 <= 0)
                    break;
                var list1 = Enumerable.Range(0, size1).Select(o => '.').ToList();
                var list2 = Enumerable.Range(0, size2).Select(o => '#').ToList();
                var result = list1.Mix(list2);
                Console.WriteLine(String.Join(" ", result));
                Console.WriteLine();
            }
        }
    }
