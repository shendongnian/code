        static bool HashIt(Encoding source, Encoding dest, string input, string expectedOutput)
        {
            byte[] bytes = source.GetBytes(input);
            if (source != dest && dest != null)
                bytes =  Encoding.Convert(source, dest, bytes);
            var hash = SHA512.Create().ComputeHash(bytes);
            var hashString = string.Concat(hash.Select(b => b.ToString("X2")));
            if (hashString.Equals(expectedOutput))
            {
                Console.WriteLine("Match found");
                Console.WriteLine("Source encoding: {0}", source.WebName);
                if (source != dest && dest != null)
                    Console.WriteLine("Converted to: {0}", dest.WebName);
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            var inputs = new [] { "13338170AS875HEO49F8Sam-PC", @"13338170AS875HEO49F8Sam-PC" };
            var expectedOutput = "A91A64DD4DF1880651CB6B919BE02C4363ED6D4B07EA246CF47FFB509918E4AA4C294FF8BA9F73E5‌​CD1CE463BB3E66F84A6C294D70C781CD0610345BCADEEDA7";
            var encodings = Encoding.GetEncodings().Select(e => e.GetEncoding());
            var matchFound = false;
            foreach (var srcEncoding in encodings)
            {
                foreach (var input in inputs)
                {
                    if (HashIt(srcEncoding, null, input, expectedOutput))
                        matchFound = true;
                    foreach (var destEncoding in encodings)
                    {
                        if (HashIt(srcEncoding, destEncoding, input, expectedOutput))
                            matchFound = true;
                    }
                }
            }
            if (!matchFound)
                Console.WriteLine("No matches found");
            Console.ReadLine();
        }
