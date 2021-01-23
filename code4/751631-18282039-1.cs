    private void RemoveTabByHeader(string str) 
    {
        TabsMain.Items.OfType<TabItem>().Where(t => Convert.ToString(t.Header) == str)
           .ToList().ForEach(t => TabsMain.Items.Remove(t));
    }
