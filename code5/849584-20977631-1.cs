    int[] ids;
    var parsable = false;
    try
    {
        ids = SearchTerm.Split(',').Select(int.Parse).ToArray();
        parsable = true;
    }
    catch
    {
        // Intentionally suppressed.
    }
