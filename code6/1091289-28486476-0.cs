    public static class Extensions
    {
        public static IEnumerable<string> DistinctBySubString(this IEnumerable<string> strings)
        {
            var results = new List<string>();
            foreach (var s in strings)
            {
                bool add = true;
                for(int i=results.Count-1; i>=0; i--)
                {
                    if (s.StartsWith(results[i]))
                    {
                        results.RemoveAt(i);
                    }
                    else if (results[i].StartsWith(s))
                    {
                        add = false;
                    }
                }
                if (add)
                    results.Add(s);
            }
            return results;
        }
    }
