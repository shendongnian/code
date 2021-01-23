	var enumerator = File.ReadLines().GetEnumerator();
	enumerator.MoveNext(); // TODO: Check result
	var current = enumerator.Current;
	while(true)
	{
		if(enumerator.MoveNext())
			// current is a Normal item
		else
		{
			// current is the last item
			// do your special thing and then exit the loop
			break;
		}
		current = enumerator.Current;
	}
