    public static Dictionary<int,string> listToMail(string startAtName, int needed)
        {
            var firstPart = r.SkipWhile(e => e.Name != startAtName);
            var secondPart = r.TakeWhile(e => e.Name != startAtName);
            var results = firstPart.Union(secondPart)
                .Where(e => e.Status == "yes")
                .Take(needed)
                .Select((e, i) => new { Key = i, Name = e.Name })
                .ToDictionary(kv => kv.Key, kv => kv.Name);
            if (results.Any())
                return results;
            else
                return null;
        }
