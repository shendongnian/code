        static void Main(string[] args)
        {
            int[] a1 = new int[] { 1, 2, 3 };
            int[] a2 = a1;
            Console.WriteLine("A1 Length: {0}", a1.Length); // will be 3
            Console.WriteLine("A2 Length: {0}", a2.Length); // will be 3
            Array.Resize(ref a1, 10);
            Console.WriteLine("A1 Length: {0}", a1.Length); // will be 10
            Console.WriteLine("A2 Length: {0}", a2.Length); // will be 3 - not good
            Console.ReadLine();
        }
