    public string GetDynamicEndpoint(dynamic parameters)
	{
		if (!Uri.Contains("{") && !Uri.Contains("}"))
			return Uri;
		var valueDictionary = GetUriParameterValueDictionary(parameters);
		string newUri = Uri;
		foreach (KeyValuePair<string, string> pair in valueDictionary)
			newUri = newUri.Replace(string.Format("{{{0}}}", pair.Key), pair.Value);
		return newUri;
	}
	private Dictionary<string, string> GetUriParameterValueDictionary(object parameters)
	{
		var propBag = parameters.ToPropertyDictionary();
		return GetUriParameters().ToDictionary(s => s, s => propBag[s]);
	}
	private IEnumerable<string> GetUriParameters()
	{
		Regex regex = new Regex(@"(?<={)\w*(?=})");
		var matchCollection = regex.Matches(Uri);
		return (from Match m in matchCollection select m.Value).ToList();
	}
