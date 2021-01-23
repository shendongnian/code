    private void UpdateSequence(Item item)
    {
    	if (item.IsItemMissingPrior(item.NextItem))
    	{
    		var inBetweenItem = item.NextItem.CreatePreviousItem();
    		inBetweenItem.NextItem = item.NextItem;
    		item.NextItem = inBetweenItem;
    		UpdateSequence(item);
    	}
    }
