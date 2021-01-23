    void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
    	XDocument doc = XDocument.Parse(e.Result);
    	List<Item> list = new List<Item>();
    	foreach (var x in doc.Descendants("row"))
    	{
    		var values = x.Elements("value").ToList();
    		var item = new Item();
    		item.ItemLine1 = values[0].Value;
            item.ItemLine2 = values[1].Value;
    		list.Add(item);
    	}
    	Dispatcher.BeginInvoke(new Action(() => ListBox1.ItemsSource = list));
    }
