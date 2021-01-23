    private static List<List<string>> GroupBy(List<string> pages, int groupSize)
    {
        var i = 0;
        return pages.GroupBy(p => i++ / 3, (k, g) => g.ToList()).ToList();
    }
