    public void BuildFormUrlEncodedDataString(Type type, object obj, StringBuilder builder, string prefix = "")
    {
    
    	var props = type.GetProperties();
    	foreach (var prop in props)
    	{
    		if (prop.CanRead)
    		{
    			if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType.IsGenericType)
    			{
    				IEnumerable list = (IEnumerable)prop.GetValue(obj);
    				if (list != null)
    				{
    					var i = 0;
    					foreach (var item in list)
    					{
    						if (item != null)
    						{
    							prefix += string.Format("{0}[{1}].", HttpUtility.UrlEncode(prop.Name), i);
    							BuildFormUrlEncodedDataString(item.GetType(), item, builder, prefix);
    							i++;
    						}
    					}
    				}
    			}
    			else  if (prop.PropertyType.IsPrimitive || prop.PropertyType.Equals(typeof(String)))
    			{
    				var item = prop.GetValue(obj);
    				if (item != null)
    				{
    					builder.AppendFormat("{0}{1}{2}={3}",
    						builder.Length == 0 ? string.Empty : "&",
    						prefix,
    						prop.Name,
    						HttpUtility.UrlEncode(item.ToString())
    					);
    				}
    			}
    			else
    			{
    			    var item = prop.GetValue(obj);
    				if (item != null)
    				{
    					prefix += string.Format("{0}.", HttpUtility.UrlEncode(prop.Name));
    					BuildFormUrlEncodedDataString(item.GetType(), item, builder, prefix);
    				}
    			}
    		}
    	}
    }
