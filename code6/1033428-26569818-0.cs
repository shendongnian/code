	var dictionary =
		xd
			.Descendants("Pet")
			.ToDictionary(
				x => x.Attribute("name").Value,
				x => x.Elements()
					.ToDictionary(
						y => y.Name,
						y => y.Attribute("name").Value));
