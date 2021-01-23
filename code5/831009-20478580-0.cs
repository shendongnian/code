	public string FormatString(string value, string format = "")
	{
		if (String.IsNullOrEmpty(value) || String.IsNullOrEmpty(format))
			return value;
		var newValue = new StringBuilder(format);
		for (int i = 0; i < newValue.Length; i++)
		{
			if (newValue[i] == '#')
				if (value.Length > 0)
				{
					newValue[i] = value[0];
					value = value.Substring(1);
				}
				else
				{
					newValue[i] = '0';
				}
		}
		return newValue.ToString();
	}
