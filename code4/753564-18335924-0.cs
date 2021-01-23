        static void Main(string[] args)
        {
            long count = 5000000;
            //Get 5,000,000 random strings (the superset)
            var strings = CreateRandomStrings(count);
            //Get 1000 random strings (the subset)
            var substrings = CreateRandomStrings(1000);
            //Perform the hashing technique
            var start = DateTime.Now;
            var hash = new HashSet<string>(strings);
            var mid = DateTime.Now;
            var any = substrings.All(hash.Contains);
            var end = DateTime.Now;
            Console.WriteLine("Hashing took " + end.Subtract(start).TotalMilliseconds + " " + mid.Subtract(start).Milliseconds + " of which was setting up the hash");
            //Do the scanning all technique
            start = DateTime.Now;
            any = substrings.All(strings.Contains);
            end = DateTime.Now;
            Console.WriteLine("Scanning took " + end.Subtract(start).TotalMilliseconds);
            //Do the Excepting technique
            start = DateTime.Now;
            any = substrings.Except(strings).Any();
            end = DateTime.Now;
            Console.WriteLine("Excepting took " + end.Subtract(start).TotalMilliseconds);
            Console.ReadKey();
            
        }
        private static string[] CreateRandomStrings(long count)
        {
            var rng = new Random(DateTime.Now.Millisecond);
            string[] strings = new string[count];
            byte[] bytes = new byte[8];
            for (long i = 0; i < count; i++) {
                rng.NextBytes(bytes);
                strings[i] = Convert.ToBase64String(bytes);
            }
            return strings;
        }
