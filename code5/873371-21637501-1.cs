        static void Main(string[] args)
        {
            string S = "tokyo";
            string T = "kyoto";
            if (S.Length == T.Length)
            {
                if (S.Intersect(T).Any())
                {
                    Console.WriteLine("The Contents are the same");
                    Console.Read();
                }
            }
            else
            Console.WriteLine("This two words are diferent. No result found.");
            Console.Read();
        }
