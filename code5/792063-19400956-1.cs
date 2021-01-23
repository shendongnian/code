    foreach (int catId in catIds.Distinct())
    {
        nameMatches = nameMatches.Where(c => c.Match.CatId == catId);
        var primaryMatch = null;
        nameMatches = nameMatches.Except(nameMatches.Where(c => c != primaryMatch)); 
    }
