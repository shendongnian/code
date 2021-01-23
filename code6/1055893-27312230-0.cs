    private static readonly Dictionary<string, IEnumerable<Results>> CachedResults = 
                                          new Dictionary<string, IEnumerable<Results>>();
    protected void OnTreeViewSelectionChanged(object sender, EventArgs e)
    {
        // I'm not overly familar with the treeview off the top of my head,
        // so get selectedValue however you would normally.
        var selectedValue = ????;
        IEnumerable<Results> results;
        // Try to find the already cached results and if false, load them 
        if (!CachedResults.TryGet(selectedValue, out results))
        {
            // GetResults should use your current methodology for getting the results
            results = GetResults(selectedValue);
            CachedResults.Add(selectedValue, results);
        }
        myGridView.DataSource = results;
    }
