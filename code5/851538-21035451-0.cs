	private void Validate(int index, object value)
	{
		/* snip */
		if (((SqlParameter) value).ParameterName.Length == 0)
		{
			string str;
			index = 1;
			do
			{
				str = "Parameter" + index.ToString(CultureInfo.CurrentCulture);
				index++;
			}
			while (-1 != this.IndexOf(str));
			((SqlParameter) value).ParameterName = str;
		}
	}
