    public static List<int> Shuffle(List<int> ints)
    {
        var random = new Random();
        var result = ints.ToList();
        var hs = new HashSet<int>(ints);
        for (int i = 0; i < ints.Count; i++)
        {
            result[i] = ints.Where((x, j) => j != i).Intersect(hs).OrderBy(x => random.Next()).First();
            hs.Remove(result[i]);
        }
        return result;
    }
