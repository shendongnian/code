    var comments
        = Set<QaComment>()
          .Select(c => new { c, sum = c.Votes.Sum(v => v.Value))
          .AsEnumerable() // to make next query execute as LINQ to Objects query
          .Select(x => { x.c.OverallVote = x.sum; return x.c; })
          .ToList();
