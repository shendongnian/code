	public IEnumerable<ItemDto> GetItemsByType2(int itemId, ItemType itemType)
	{
		var cases = new Dictionary<ItemType, Func<IEnumerable<ItemDto>, IEnumerable<ItemDto>>>()
		{
			{ ItemType.Normal, xs => xs },
			{ ItemType.Damaged, xs =>
				from item in xs
				join itemDetail in _ItemDetails.Get() on item.ID equals itemDetail.ItemID
				select item },
			{ ItemType.Fixed, xs =>
				from item in xs
				join itemDetail in _ItemDetails.Get() on item.ID equals itemDetail.ItemID
				where item.Status.ToLower() == "fixed"
				select item },
		};
		
		return cases[itemType](_Items.Get(i => i.ItemId == itemId && o.Active == true))
			.Select(x => new ItemDto { .... });
	}
