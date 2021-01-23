    private Dictionary<string, object> GetModifiedProperties(TModel model)
    {
	var entry = Context.Entry(model);
	// entry is detached.
	// set entry to database entry and its CurrentValues to model values
	if (entry.State == EntityState.Detached)
	{
		object key = model.GetType().GetProperty("Id").GetValue(model);
		if (key == null)
		{
			throw new InvalidOperationException("The Entity you desire to update does not contain an Id value.");
		}
		var dbModel = Context.Set<TModel>().Find(key);
		var dbEntry = Context.Entry(dbModel);
		dbEntry.CurrentValues.SetValues(model);
		entry = dbEntry;
		//entry.State = EntityState.Modified;
	}
	var modifiedProps = new Dictionary<string, object>();
	foreach (var propertyName in entry.CurrentValues.PropertyNames)
	{
		// copy only changed values to dict
		var prop = entry.Property(propertyName);
		if (prop.IsModified)
		{
			modifiedProps.Add(propertyName, prop.OriginalValue);
		}
	}
	return modifiedProps;
    }
