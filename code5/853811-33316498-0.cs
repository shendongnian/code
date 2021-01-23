    public static string ToJson(ResourceManager rm) {
		Dictionary<string, string> pair = new Dictionary<string, string>();
		ResourceSet resourceSet = rm.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
		
		resourceSet.Cast<DictionaryEntry>().ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());
		
		string json = "";
		
		foreach (DictionaryEntry item in resourceSet) {
		    if (json != "") { json += ", "; }
		    json += "\"" + item.Key + "\": \"" + item.Value + "\"";
		}
		
		return "{ " + json + " }";
	}
