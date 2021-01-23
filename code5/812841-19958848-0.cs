    static void Main(string[] args)
        {
            int[] array = { 12, 45, 23, 3, 67, 43 };
            Array.Sort(array);
            int index1 = Array.BinarySearch<int>(array, 45);
            int index2 = Array.BinarySearch<int>(array, 3);
            Console.WriteLine(index1);
            Console.WriteLine(index2);
        }
