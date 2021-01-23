    public ProxiesList()
    {
    	GridItems = new ObservableCollection<ProxiesList>();
    	mw.dataGrid1.ItemsSource = GridItems;
    }
    
    public void addTheData(MainWindow mw, List<string> proxyList)
    {
    	foreach (string line in proxyList)
    	{
    		GridItems.Add(new ProxiesList //add items to the collection
    		{
    			proxy = line.Split(';')[0],
    			proxySource = line.Split(';')[1],
    			proxyUsed = false,
    			toUse = true,
    			working = "n/a"
    		});
    	}
    }
