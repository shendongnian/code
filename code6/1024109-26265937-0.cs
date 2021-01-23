	FileInfo info = new FileInfo(filePath);
	DateTime oldTime = info.LastWriteTimeUtc;
	while(true)
	{
		do
		{
			await Task.Wait(1000);
			info.Refresh();
		} while(info.LastWriteTimeUtc == oldTime);
		try
		{
			using(Stream s = File.OpenRead(filePath))
			{
				// ok, file was modified and is unlocked. copy back.
			}
			
			break;
		}
		catch(IOException)
		{
			// file is locked, retry.
			oldTime = info.LastWriteTimeUtc;
		}
	}
