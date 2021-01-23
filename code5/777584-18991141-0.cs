	IEnumerable newCollection = businessObjectCollection.Cast<object>().Select((o) =>
	{
		Type t = o.GetType();
		PropertyInfo identifierProperty = o.GetType().GetProperty("Identifier");
		long entityID = (long)identifierProperty.GetValue(o, null);
		if (replacementEntity.Identifier == entityID)
		{
			return replacementEntity;
		}
		return o;
	});
