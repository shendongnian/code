public static TDest MapSourceToDest<TSource, TDest>(TSource source)
									where TSource : class, new()
									where TDest : class, new()
{
	TDest destination = new TDest();
	var typeOfSource = source.GetType();
	var typeOfDestination = destination.GetType();
	foreach(var fieldOfSource in typeOfSource.GetFields())
	{
		var fieldOfDestination = typeOfDestination.GetField(fieldOfSource.Name);
		if(fieldOfDestination != null)
			fieldOfDestination.SetValue(destination, fieldOfSource.GetValue(source));
	}
	foreach(var propertyOfSource in typeOfSource.GetProperties())
	{
		var propertyOfDestination = typeOfDestination.GetProperty(propertyOfSource.Name);
		if(propertyOfDestination != null)
			propertyOfDestination.SetValue(destination, propertyOfSource.GetValue(source));
	}
	return destination;
}
One may need to alter the filters on generic types; but everything else will work cross any types. Null check is added for `fieldOfDestination` and `propertyOfDestination` just in case a member is missing; this adds up little more flexibility.
