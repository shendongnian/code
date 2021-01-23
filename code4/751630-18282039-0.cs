    private void RemoveTabByHeader(string str) 
    {
        TabsMain.Items.OfType<TabItem>().Where(t => (t.Header as String) == str)
           .ToList().ForEach(t => TabsMain.Items.Remove(t));
    }
