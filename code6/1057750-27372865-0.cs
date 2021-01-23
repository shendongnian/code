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
                .SelectMany(item => item)
                .GroupBy(item => item)
                .Select(group => new { Count = group.Count(), Item = group.Key })
                .Where(x => x.Count == stringLists.Length);
        }
    }
