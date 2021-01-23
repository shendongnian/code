    foreach(var entry in Enum.GetNames(typeof(TextType)))
    {
    	if (Regex.IsMatch(input, string.Format(@"\b{0}\b", Regex.Escape(entry))))
    	{
            return entry;
    	}
    }
    return TextType.SomeDefaultValue;
