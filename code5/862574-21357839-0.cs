    var xml = new XElement(
            "array", 
            data.Select(d => 
               new XElement("dict",
				d.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name != "RelationshipManager")
				.Select(
					p => new [] { 
						new XElement("key",p.Name), 
						new XElement("string", p.GetValue(d, null)) }
				)
			)
		));
