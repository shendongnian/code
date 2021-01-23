        static void Main(string[] args)
        {
            int test = 1;
            Increment(test);
            Console.WriteLine("After increment: " + test);
        }
        static void Increment(int test)//add ref and the original variable will also update
        {
            test += 1;
            Console.WriteLine(test);
        }
