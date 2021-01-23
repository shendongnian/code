    var givenValue = "t1";
    var heads = new[] { // your repo.Heads query here: heads = repo.Heads.Where(w.Expand()).OrderBy(x => x.IdFolder).Take(taked);
    	new {IdFolder = 1, Details = new[]{new {Code = "a", IType = "t1"}, new {Code = "b", IType = "t2"}}},
    	new {IdFolder = 2, Details = new[]{new {Code = "c", IType = "t2"}, new {Code = "d", IType = "t1"}}},
    };
    
    // Db hit.
    var q = heads; 
    var details = q.SelectMany(
        h=>h.Details
            .Where(d=>d.IType == givenValue)
            .Select(d=>new{HeadId = h.IdFolder, d.Code})).ToList();
    
    // O(N) in-memory.
    var grid = details
        .ToLookup(d=>d.HeadId)
        .Select(g=>new{HeadId = g.Key, Codes = string.Join(",",g.Select(i=>i.Code))})
        .ToList();
