	var valuesToSet = new Dictionary<string, object> 
					  {
							{"BitmapUnembeddableFonts", false}, 
							{"UsePdaA", true}
					  };
	var settings = new FixedFormatSettings();
	
	var properties = settings.GetType()
							 .GetProperties()
							 .Where(p => p.CanWrite);
	
	foreach (var property in properties)
	{
		object valueToSet;
		if(valuesToSet.TryGetValue(property.Name, out valueToSet))
		{
			property.SetValue(settings, valueToSet);
		}
	}
	Console.WriteLine(settings.BitmapUnembeddableFonts); //false
	Console.WriteLine(settings.UsePdaA); //true
