        public static void Main(string[] args)
        {
            var allowed = new List<string> { "a", "b", "c" };
            var read = Console.ReadLine().Select(c => c.ToString()).ToList();
            if (read.All(allowed.Contains))
            {
                Console.WriteLine("Okay");
            }
            else
            {
                var firstNotAllowed = read.First(a => !allowed.Contains(a));
                var firstIndex = read.FindIndex(a => !allowed.Contains(a));
                Console.WriteLine("Invalid char: {0}, at index: {1}", firstNotAllowed, firstIndex);
            }
        }
