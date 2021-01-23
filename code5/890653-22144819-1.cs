	_acceptedCardTypes
		.AddRange(
			xml
				.Descendants("Card")
				.Select(x => new AcceptedCardTypes()
				{
					CardName = x.Value,
					CardType = x.Attribute("type").Value,
				}));
