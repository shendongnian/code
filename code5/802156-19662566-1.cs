	foreach (var entry in entries)
	{
		try
		{
			ProcessEntry(entry);
		}
		catch (EntityProcessingException ex)
		{
			// Log, don't care, whatever ex
		}
	}
