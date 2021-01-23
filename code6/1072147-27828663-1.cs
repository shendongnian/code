    protected internal override string GetModStampInChild<T>(int sid) where T : Stampable
    {
        using (var sq = new DbContext())
        {
          return sq.Set<T>.Where(s => s.id == sid)
                          .Select(s => s.modstamp)
                          .SingleOrDefault()
                          .ToModStampString();
        }
    }
