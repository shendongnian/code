    var summary = new Dictionary<int, Transaction>();
    foreach(var item in items)
    {
    	Transaction t;
    	if(!summary.TryGetValue(item.Id, t)) 
    	{
    		t = new Transaction(item.Id);
    		summary[t.Id] = t;
    	}
    	
    	t.Items.Add(new Item { quantity = item.quantity, itemName = item.itemName});
    }
