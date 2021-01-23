    ...
    
    var rule = x => GetTextToFilter(x).IndexOf(filterText,
                    StringComparison.CurrentCultureIgnoreCase) >= 0;
    
    foreach (var group in Groups)
    {
    	group.UpdateVisibleItems(rule);
    }
    
    ...
    
    void UpdateVisibleItems(Func<ItemViewModel, bool> rule)
    {
    	for (int i = 0, j = 0; i < AllItems.Count; i++)
    	{
    		var item = AllItems[i];
    		if (rule(item))
    		{
    			if (j == _Items.Count || (j < _Items.Count && _Items[j] != item))
    			{
    				_Items.Insert(j, item);
    			}
    
    			j++;
    		}
    		else
    		{
    			if (j < _Items.Count && _Items[j] == item)
    			{
    				_Items.RemoveAt(j);
    			}
    		}
    	}
    }
