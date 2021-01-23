	void ProcessEntries(entries)
	{
		foreach (var entry in entries)
		{
			try
			{
				ProcessEntry(entry);
			}
			catch (EntryProcessingException ex)
			{
				// Log the exception
			}
		}
	}
