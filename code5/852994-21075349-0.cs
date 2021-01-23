    private readonly IList<IHelper> helpers;
    ...
    public void UseHelpers()
    {
        foreach (dynamic helper in helpers)
        {
            UseHelper(helper); // Figures out type arguments itself
        }
    }
    private void UseHelper<T>(IHelper<T> helper)
    {
        // Now you're in a generic method, so can use T appropriately
    }
