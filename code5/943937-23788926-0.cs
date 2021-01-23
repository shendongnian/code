    try
    {
        InsertOrUpdatePort(tsp, username);
    }
    catch (DbUpdateException e)
    {
        throw new Exception("Friendly message here", e)
    }
