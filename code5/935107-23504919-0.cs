    public string[] GetMyGameList()
    {
         var query = db.BisGame.GroupBy(bg => bg.Initials)
                  .Take(10)
                  .Select(g => new { Initial = g.Key, MaxScore = g.Max(bg => bg.Score) });
         // Convert to string[] somehow, ie:
         return query.AsEnumerable().Select(i => string.Format("{0}:{1}", i.Initial, i.MaxScore)).ToArray();
    }
