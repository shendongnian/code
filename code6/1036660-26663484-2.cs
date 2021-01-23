        static void Main(string[] args)
        {
            string x = "hi", y = "hi", z = string.Concat('h', 'i');
            Console.WriteLine(ReferenceEquals(x, y));   // true
            Console.WriteLine(ReferenceEquals(x, z));   // false
            Console.WriteLine(Equals(x, y));   // true
            Console.WriteLine(Equals(x, z));   // true
            
            Console.ReadLine();
        }
