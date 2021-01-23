    public IList<string> SearchByArticleCount(int articleCount)
    {
        return _Items.AsNoTracking().Where(m => m.Articles.Count().Equals(articleCount))
            .Take(_SearchTakeCount)
            .Select(m => m.Articles.Count())
            .Distinct()
            .AsEnumerable()
            .Select(x => x.ToString())
            .ToList();
    }
