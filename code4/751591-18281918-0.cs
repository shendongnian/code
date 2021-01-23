	using (var input = new ZipInputStream(new MemoryStream(zipBytes)))
	{
		ZipEntry e;
		while ((e = input.GetNextEntry()) != null)
		{
			if (e.IsDirectory) continue;
			using (var output = File.Open(e.FileName, FileMode.Create, FileAccess.ReadWrite))
			{
				while ((n = input.Read(buffer, 0, buffer.Length)) > 0)
				{
					output.Write(buffer, 0, n);
				}
			}
		}
	}
