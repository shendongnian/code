    private static List<List<string>> GroupBy(List<string> pages, int groupSize)
    {
        return pages.Select(p => new { p, i })
                    .GroupBy(x => x.i / 3)
                    .Select(g => g.Select(x => x.p).ToList())
                    .ToList();
    }
