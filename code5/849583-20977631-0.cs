    int[] ids;
    var parasable = false;
    try
    {
        ids = SearchTerm.Split(',').Select(int.Parse).ToArray();
        parasable = true;
    }
    catch
    {
        // Intentionally suppressed.
    }
