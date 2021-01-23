	public static List<object[]> Serialise2D_Rec(IList data)
	{
		int numElts = 0;
		foreach (var item in data)
			numElts++;
		if (data.Count == 0)
			throw new Exception("Cannot handle empty lists.");
		Type t = data[0].GetType(); // Get type pointer
		PropertyInfo[] propList = t.GetProperties();
		List<object[]> toret = new List<object[]>();
		for (long propID = 0; propID < propList.Count(); ++propID)
		{
			var proptype = propList[propID].PropertyType;
			if (proptype.IsPrimitive || proptype == typeof(Decimal) || proptype == typeof(String))
			{
				toret.Add(new object[numElts + 1]);
				toret[toret.Count - 1][0] = propList[propID].Name;
				int row = 1;
				foreach (object item in data)
				{
					toret[toret.Count - 1][row] = propList[propID].GetValue(item, null);
					row++;
				}
			}
			else
			{
				var lst = (IList)Activator.CreateInstance((typeof(List<>).MakeGenericType(proptype)));
				foreach (object item in data)
				{
					lst.Add(propList[propID].GetValue(item, null));
				}
				List<object[]> serialisedProp = Serialise2D_Rec(lst);
			}
		}
		return toret;
	}
