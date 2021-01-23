	public static void Main(string[] args)
	{
		var xelement = XElement.Load("data.xml");
		var employees = xelement.Elements()
			.Select(e => new
			{
				Element = e,
				Name = e.Element("Employee").Value,
				ChangeTimeStamp = DateTime.Parse(e.Element("ChangeTimeStamp").Value)
			})
			.GroupBy(e => e.Name)
			.Select(g => 
			{
				var maxTimestamp = g.Max(e => e.ChangeTimeStamp);
				foreach (var e in g)
				{
					if (e.ChangeTimeStamp < maxTimestamp)
					{
						e.Element.Remove();
					}
				}
				
				return new
				{
					Name = g.Key,
					ChangeTimeStamp = maxTimestamp
				};
			});		
		
        xelement.Save(yourPathToSave);
	}
