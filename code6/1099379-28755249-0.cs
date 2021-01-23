	foreach (JProperty nameProp in startsWithJ)
	{
		Console.WriteLine(nameProp.Value);
		Console.WriteLine(((JProperty)nameProp.Parent.Parent.Parent).Name);
	}
