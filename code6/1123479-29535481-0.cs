    public static object FilteringProperties(object employee, List<string> fields)
	{
		if (!fields.Any())
			return employee;
		else
		{
			ExpandoObject result = new ExpandoObject();
			foreach (var field in fields)
			{
				object fieldValue = null;
				
				Regex regex = new Regex("(\\w+)\\.(\\w+)");
				Match match = regex.Match(field);
				if (match.Success)
				{
					string className = match.Groups[1].Value;
					string propertyName = match.Groups[2].Value;
					var o = FilteringProperties(employee.GetType().GetProperty(className).GetValue(employee, null), new List<string>() {propertyName});
					var entry = (IDictionary<string, object>) o;
					fieldValue = entry[propertyName];
				}
				if(fieldValue == null)
					fieldValue = employee.GetType()
					.GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
					.GetValue(employee, null);
				((IDictionary<String, Object>)result).Add(field, fieldValue);
			}
			return result;
		}
	}
