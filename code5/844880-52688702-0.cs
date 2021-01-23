    public static NameValueCollection GetFixedQueryString(NameValueCollection originalQueryString)
	{
		  var fixedQueryString = new NameValueCollection();
		  for (var i = 0; i < originalQueryString.AllKeys.Length; i++)
		  {
			  string keyName = originalQueryString.AllKeys[i];
			  string value;
			  if (keyName == null)
			  {
				  // This is the fix
				  keyName = originalQueryString[i];
				  value = null;
				  //
			  }
			  else
			  {
				  value = originalQueryString[keyName];
			  }
			  fixedQueryString.Add(keyName, value);
		  }
		  return fixedQueryString;
	 }
