    // System.Web.HttpValueCollection
    internal virtual string ToString(bool urlencoded, IDictionary excludeKeys)
    {
    	int count = this.Count;
    	if (count == 0)
    	{
    		return string.Empty;
    	}
    	StringBuilder stringBuilder = new StringBuilder();
    	bool flag = excludeKeys != null && excludeKeys["__VIEWSTATE"] != null;
    	for (int i = 0; i < count; i++)
    	{
    		string text = this.GetKey(i);
    		if ((!flag || text == null || !text.StartsWith("__VIEWSTATE", StringComparison.Ordinal)) && (excludeKeys == null || text == null || excludeKeys[text] == null))
    		{
    			if (urlencoded)
    			{
    				text = HttpValueCollection.UrlEncodeForToString(text);
    			}
    			string value = (text != null) ? (text + "=") : string.Empty;
    			string[] values = this.GetValues(i);
    			if (stringBuilder.Length > 0)
    			{
    				stringBuilder.Append('&');
    			}
    			if (values == null || values.Length == 0)
    			{
    				stringBuilder.Append(value);
    			}
    			else
    			{
    				if (values.Length == 1)
    				{
    					stringBuilder.Append(value);
    					string text2 = values[0];
    					if (urlencoded)
    					{
    						text2 = HttpValueCollection.UrlEncodeForToString(text2);
    					}
    					stringBuilder.Append(text2);
    				}
    				else
    				{
    					for (int j = 0; j < values.Length; j++)
    					{
    						if (j > 0)
    						{
    							stringBuilder.Append('&');
    						}
    						stringBuilder.Append(value);
    						string text2 = values[j];
    						if (urlencoded)
    						{
    							text2 = HttpValueCollection.UrlEncodeForToString(text2);
    						}
    						stringBuilder.Append(text2);
    					}
    				}
    			}
    		}
    	}
    	return stringBuilder.ToString();
    }
    internal static string UrlEncodeForToString(string input)
    {
    	return HttpUtility.UrlEncodeUnicode(input);
    }
