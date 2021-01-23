    public class MyResultClass
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
    }
    private static readonly Dictionary<string, IEnumerable<MyResultClass>> 
        CachedResults = new Dictionary<string, IEnumerable<MyResultClass>>();
    protected void OnTreeViewSelectionChanged(object sender, EventArgs e)
    {
        // I'm not overly familar with the treeview off the top of my head,
        // so get selectedValue however you would normally.
        var selectedValue = ????;
        IEnumerable<MyResultClass> results;
        // Try to find the already cached results and if false, load them 
        if (!CachedResults.TryGet(selectedValue, out results))
        {
            // GetResults should use your current methodology for getting the results
            results = GetResults(selectedValue);
            CachedResults.Add(selectedValue, results);
        }
        myGridView.DataSource = results;
    }
