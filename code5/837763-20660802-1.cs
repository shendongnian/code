	flatList
		.GroupBy(i => i.FatherId)
        .Select(g => new Father()
		{
			id = g.Key,
			propertyF,
			children =
				g
					.Select(c => new Child()
					{
						id = ChildrenId,
						prop1,
						prop2
					})
					.ToList()
		})
            
          
