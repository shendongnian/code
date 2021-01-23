    public static CookieCollection GetAllCookiesFromHeader(string strHeader, string strHost)
    {
    	ArrayList al = new ArrayList();
    	CookieCollection cc = new CookieCollection();
    	if (strHeader != string.Empty)
    	{
    		al = ConvertCookieHeaderToArrayList(strHeader);
    		cc = ConvertCookieArraysToCookieCollection(al, strHost);
    	}
    	return cc;
    }
    
    
    private static ArrayList ConvertCookieHeaderToArrayList(string strCookHeader)
    {
    	strCookHeader = strCookHeader.Replace("\r", "");
    	strCookHeader = strCookHeader.Replace("\n", "");
    	string[] strCookTemp = strCookHeader.Split(',');
    	ArrayList al = new ArrayList();
    	int i = 0;
    	int n = strCookTemp.Length;
    	while (i < n)
    	{
    		if (strCookTemp[i].IndexOf("expires=", StringComparison.OrdinalIgnoreCase) > 0)
    		{
    			al.Add(strCookTemp[i] + "," + strCookTemp[i + 1]);
    			i = i + 1;
    		}
    		else
    		{
    			al.Add(strCookTemp[i]);
    		}
    		i = i + 1;
    	}
    	return al;
    }
    
    
    private static CookieCollection ConvertCookieArraysToCookieCollection(ArrayList al, string strHost)
    {
    	CookieCollection cc = new CookieCollection();
    
    	int alcount = al.Count;
    	string strEachCook;
    	string[] strEachCookParts;
    	for (int i = 0; i < alcount; i++)
    	{
    		strEachCook = al[i].ToString();
    		strEachCookParts = strEachCook.Split(';');
    		int intEachCookPartsCount = strEachCookParts.Length;
    		string strCNameAndCValue = string.Empty;
    		string strPNameAndPValue = string.Empty;
    		string strDNameAndDValue = string.Empty;
    		string[] NameValuePairTemp;
    		Cookie cookTemp = new Cookie();
    
    		for (int j = 0; j < intEachCookPartsCount; j++)
    		{
    			if (j == 0)
    			{
    				strCNameAndCValue = strEachCookParts[j];
    				if (strCNameAndCValue != string.Empty)
    				{
    					int firstEqual = strCNameAndCValue.IndexOf("=");
    					string firstName = strCNameAndCValue.Substring(0, firstEqual);
    					string allValue = strCNameAndCValue.Substring(firstEqual + 1, strCNameAndCValue.Length - (firstEqual + 1));
    					cookTemp.Name = firstName;
    					cookTemp.Value = allValue;
    				}
    				continue;
    			}
    			if (strEachCookParts[j].IndexOf("path", StringComparison.OrdinalIgnoreCase) >= 0)
    			{
    				strPNameAndPValue = strEachCookParts[j];
    				if (strPNameAndPValue != string.Empty)
    				{
    					NameValuePairTemp = strPNameAndPValue.Split('=');
    					if (NameValuePairTemp[1] != string.Empty)
    					{
    						cookTemp.Path = NameValuePairTemp[1];
    					}
    					else
    					{
    						cookTemp.Path = "/";
    					}
    				}
    				continue;
    			}
    
    			if (strEachCookParts[j].IndexOf("domain", StringComparison.OrdinalIgnoreCase) >= 0)
    			{
    				strPNameAndPValue = strEachCookParts[j];
    				if (strPNameAndPValue != string.Empty)
    				{
    					NameValuePairTemp = strPNameAndPValue.Split('=');
    
    					if (NameValuePairTemp[1] != string.Empty)
    					{
    						cookTemp.Domain = NameValuePairTemp[1];
    					}
    					else
    					{
    						cookTemp.Domain = strHost;
    					}
    				}
    				continue;
    			}
    		}
    
    		if (cookTemp.Path == string.Empty)
    		{
    			cookTemp.Path = "/";
    		}
    		if (cookTemp.Domain == string.Empty)
    		{
    			cookTemp.Domain = strHost;
    		}
    		cc.Add(cookTemp);
    	}
    	return cc;
    }
