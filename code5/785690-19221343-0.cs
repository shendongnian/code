        static void FindPersons(string firstLetter)
        {
            List<string> names = new List<string>()
            {"Marcus", "John", "Jesse", "Lance", "Aaron", "Archibald", "Victor"
            };
            List<string> result = names.Where(a => a.StartsWith(firstLetter, StringComparison.InvariantCultureIgnoreCase)).ToList();
            Console.WriteLine(string.Join<string>("\n", result));
        
        }
