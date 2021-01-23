    public List<article> PageArts(int start, int limit, out int total)
    {
        var ll =
            _ent.articles.OrderByDescending(o => o.id)
                .Skip(start)
                .Take(limit)
                .Include(o => o.user)
                .ToList();
        total = _ent.articles.Count();
        return ll;
    }
