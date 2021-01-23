	var answer = 
	 typeof(Class2).GetProperties(BindingFlags.Public | BindingFlags.Instance)
	               .SelectMany(pi => mainClass.list.SelectMany(c1 => 
				   		c1.dict.Select(i => new {
													c1.PropertyA, 
													c1.PropertyB, 
													i.Key,
													i.Value}))
								.Select(p => new {
													Key = new ComplexKey {
														class1PropA = p.PropertyA,
														class1PropB = p.PropertyB,
														class1DictKey = p.Key,
														class2PropName = pi.Name},
													Value = (double)pi.GetValue(p.Value)}))
					.GroupBy(grp => grp.Key)
					.ToDictionary(grp => grp.Key, grp => grp.Select(x => x.Value));
