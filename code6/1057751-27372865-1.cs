    class Program
    {
        static void Main(string[] args)
        {
            List<string>[] stringLists = new List<string>[] 
            { 
                new List<string>(){ "a", "b", "c" },
                new List<string>(){ "d", "b", "c" },
                new List<string>(){ "a", "e", "c" }
            };
    
            // Will contian only 'c' because it's the only common item in all three groups.
            var commonItems = 
                stringLists
                .SelectMany(list => list)
                .GroupBy(item => item)
                .Select(group => new { Count = group.Count(), Item = group.Key })
                .Where(item => item.Count == stringLists.Length);
            foreach (var item in commonItems)
            {
                Console.WriteLine(String.Format("Item: {0}, Count: {1}", item.Item, item.Count));
            }
        }
    }
