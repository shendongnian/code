    foreach (int catId in catIds.Distinct())
    {
        var allCatNameMatches = nameMatches.Where(c => c.Match.CatId == catId);
        var primaryMatch = null;
        nameMatches = nameMatches.Except(allCatNameMatches.Where(c => c != primaryMatch)); 
    }
