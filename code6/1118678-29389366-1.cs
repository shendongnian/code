	public CsvPropertyMap( PropertyInfo property )
	{
		data = new CsvPropertyMapData( property )
		{
			// Set some defaults.
			TypeConverter = TypeConverterFactory.GetConverter( property.PropertyType )
		};
        var displayAttributes = property.GetCustomAttributes(typeof(CsvHeaderAttribute), inherit: false);
	    if (displayAttributes.Any()) {
            var displayName = ((CsvHeaderAttribute)displayAttributes.First()).Name;
	        data.Names.Add(displayName);
	    }
	    else {
	        displayAttributes = property.GetCustomAttributes(typeof (DisplayAttribute), inherit: false);
	        if (displayAttributes.Any()) {
	            var displayName = ((DisplayAttribute) displayAttributes.First()).Name;
	            data.Names.Add(displayName);
	        }
	        else {
	            data.Names.Add(property.Name);
	        }
	    }
	    var shouldIgnore = Attribute.GetCustomAttribute(property, typeof (CsvIgnoreAttribute), inherit: true);
	    if (shouldIgnore != null)
	        data.Ignore = true;
	}
