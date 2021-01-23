    if (done)
    	_changedPropertyNames.Add(propertyInfo.Name);
    public void Patch(T objectToPatch)
    {
    	foreach (var propertyName in _changedPropertyNames)
    	{
    		var propertyInfo = _obj.GetType().GetProperty(propertyName);
    		propertyInfo.SetValue(objectToPatch, propertyInfo.GetValue(_obj));
    	}
    }
