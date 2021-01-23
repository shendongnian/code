    if (modelList.Count == 0)
    {
    	IEnumerableValueProvider enumerableValueProvider = bindingContext.ValueProvider as IEnumerableValueProvider;
    	if (enumerableValueProvider != null)
    	{
    		IDictionary<string, string> keys = enumerableValueProvider.GetKeysFromPrefix(bindingContext.ModelName);
    		foreach (var thisKey in keys)
    		{
    			modelList.Add(CreateEntryForModel(controllerContext, bindingContext, valueType, valueBinder, thisKey.Value, thisKey.Key));
    		}
    	}
    }
    // replace the original collection
    object dictionary = bindingContext.Model;
    CollectionHelpers.ReplaceDictionary(keyType, valueType, dictionary, modelList);
    return dictionary;
