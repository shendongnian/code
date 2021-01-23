	void ProcessEntries(entries)
	{
		foreach (var entry in entries)
		{
			ProcessEntry(entry);
		}
	}
	void ProcessEntry(entry)
	{
		if (foo)
		{
			throw new EntityProcessingException();
		}
	}
