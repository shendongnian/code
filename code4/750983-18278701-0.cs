	public List<Item> sortItems(List<Item> items) {
		// perform a topological sort
		var sortedItems = 
			items.TSort(item => items.Where(o=>item.ID == o.nextID || item.nextID == ""))
			.ToList();
		// this next code moves the unpointed items to top of list
			
		// find items that are not pointed to, and do not point to any other item
		var soloItems= 
			sortedItems.Where(o => !sortedItems.Where(p => p.nextID == o.ID).Any() && o.nextID == "").ToList();
			
		// reverse the soloItems list so they
		// to appear in the same order in which 
		// they were found in unsorted list
		soloItems.Reverse();	
		
		// move the soloItems from the bottom of sortedItems to the top of sortedItems
		sortedItems.RemoveAll(o => soloItems.Contains(o));
		sortedItems.InsertRange(0,soloItems);
		
		return sortedItems;		
		
	}
