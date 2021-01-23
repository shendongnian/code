    sealed class Item {
        public Item(int group) {
    	    ItemGroup = group;
        }
    	public int ItemGroup { get; private set; }
    }
    Item TakeNextItem(IList<Item> items) {
        const int LowerBurstLimit = 1;
	
        if (items == null)
            throw new ArgumentNullException("items");
        if (items.Count == 0)
            return null;
		
        var item = items.GroupBy(x => x.ItemGroup)
                        .OrderBy(x => Math.Max(LowerBurstLimit, x.Count()))
                        .First()
                        .First();
        items.Remove(item);
        return item;
    }
