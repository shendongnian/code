    var list = new List<KeyValuePair<string,string>>();
    foreach(var e in typeof(QATypes).GetFields())
    {
    	var attribute = e.GetCustomAttributes(typeof(EnumMemberAttribute))
                                 .FirstOrDefault() as EnumMemberAttribute;
    	if(attribute != null)
    	{
    		list.Add(new KeyValuePair<string,string>(e.Name, attribute.Value));
    	}
    }
