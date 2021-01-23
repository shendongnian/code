    public static List<int> GetLongestMatch(params List<int>[] all)
    {
        var shortest = all.Where(i => i.Count == all.Select(j => j.Count).Min()).First();
        var permutations = (from length in Enumerable.Range(1, shortest.Count)
                            orderby length descending
                            from count in Enumerable.Range(1, shortest.Count - length + 1)
                            select shortest.Skip(count - 1).Take(length).ToList())
                            .ToList();
                
        Func<List<int>, string> stringfy = (list) => { return string.Join(",", list.Select(i => i.ToString()).ToArray()); };
        foreach (var item in permutations)
        {
            Debug.WriteLine(string.Join(", ", item.Select(i => i.ToString()).ToArray()));
            if (all.All(list => stringfy(list).Contains(stringfy(item))))
            {
                Debug.WriteLine("Matched, skip process and return");
                return item;
            }
        }
        return new List<int>();
    }
