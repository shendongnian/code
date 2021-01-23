	for( int i = 0; i < 10; i++ )
	{
		uint count = 0;
		string queryString = "(&(objectClass=user)(objectCategory=person)(!msExchResourceMetaData=ResourceType:Room)(!userAccountControl:1.2.840.113556.1.4.803:=2))";
		Stopwatch timer = Stopwatch.StartNew();
			
		DirectoryEntry entry = new DirectoryEntry();
		DirectorySearcher search = new DirectorySearcher(entry,queryString);
		search.PageSize = 1000;
		foreach( SearchResult result in search.FindAll() )
		{
			DirectoryEntry user = result.GetDirectoryEntry();
			if( user != null )
			{
				user.RefreshCache(new string[]{"canonicalName"});
				string canonicalName = user.Properties["canonicalName"].Value.ToString();
				count++;
			}
		}
		timer.Stop();
		Console.WriteLine("{0}, {1} ms", count, timer.ElapsedMilliseconds);
	}
