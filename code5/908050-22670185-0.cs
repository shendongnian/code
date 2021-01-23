    public static List<TreeView> ListToTree(string displayName, string groupedOn)
    {
        //seed data
        List<GenericResults> results = GenericResults.MockDatabaseCall();
        List<TreeView> trees = new List<TreeView>();
        //"group" on the property passed by the user
        var query = results.Select(x => x.GetType().GetProperty(groupedOn).GetValue(x, null)).Distinct();
        foreach (int i in query)
        {
            var treeView = new TreeView();
            treeView.Title = displayName;
            treeView.Children = results.Where(x => ((int)x.GetType().GetProperty(groupedOn).GetValue(x, null)) == i);
            trees.Add(treeView);
        }
        return trees;
    }
