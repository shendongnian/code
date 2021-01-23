    public MainWindow()
    {
        MyCollection.Add(new TabContent { Headertext = "item1" });
        MyCollection.Add(new TabContent { Headertext = "item2" });
        MyCollection.Add(new TabContent { Headertext = "item3" });
        ...
        foreach (TabContent tab in MyCollection)
        {
            tab.TabClosing += OnTabClosing;
        }
    }
