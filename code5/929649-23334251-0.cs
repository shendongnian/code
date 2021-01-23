    if (accessCodes == null)
    {
        output = output.Where(u => u.AccessCode == null);
    }
    else
    {
        var predicate = PredicateBuilder.False<User>();
    
        for (int i = 0; i <= accessCodes.Length - 1; i++)
        {
            predicate = predicate.Or(u => u.AccessCode.Contains(accessCodes[i]))
        }
    
        output = output.Where(predicate);
    }
