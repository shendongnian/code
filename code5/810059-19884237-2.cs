	for (int i = 0; i < Items.Count; i++)
	{
		// if the item is already in the list
		if (Items[i].ItemName == productName)
		{
			Items[i].UpdateShoppingBasketList(quantity, latestPrice);
			return; //replace me with something else...
		}
	}
		
