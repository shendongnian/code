	var fire = new FireElement();
	var water = new WaterElement();
	var steam = new SteamElement();
	_allElements = Dictionary<Element, Dictionary<Element,Element>>
	{
		new KeyValuePair<Element, Dictionary<Element, Element>>
		{
			Key = fire,
			Value = new KeyValuePair<Element, Element>
			{
				Key = water,
				Value = steam
			}
		},
		new KeyValuePair<Element, Dictionary<Element, Element>>
		{
			Key = water,
			Value = new KeyValuePair<Element, Element>
			{
				Key = fire,
				Value = steam
			}
		}
    
	}
