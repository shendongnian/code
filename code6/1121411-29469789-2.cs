    public override bool TryGetMember(GetMemberBinder binder, out object result)
	{
		object value;
		if (!dictionary.TryGetValue(binder.Name, out value))
		{
			result = new DynamicDictionaryValue(null);
			return true;
		}
		var dictVal = value as DynamicDictionaryValue;
		if (null != dictVal && dictVal.Value is DynamicDictionary)
		{
			result = dictVal.Value;
		}
		else
		{
			result = value;
		}
		return true;
	}
