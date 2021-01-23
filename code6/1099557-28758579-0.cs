            IEnumerable<char> query = "Not what you might expect";
            string vowels = "aeiou";
            IEnumerable<char> result = "";
            for (int i = 0; i < vowels.Length; i++)
                query = query.Where(c => c != vowels[i]).ToList(); // or .ToArray()
            foreach (char c in query) Console.Write(c);
