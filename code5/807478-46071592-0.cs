    public static Attachment CreateAttachment(string fileNameAndPath, bool zipIfTooLarge = true, int bytes = 1 << 20)
	{
		if (!zipIfTooLarge)
		{
			return new Attachment(fileNameAndPath);
		}
	
		var fileInfo = new FileInfo(fileNameAndPath);
		// Less than 1Mb just attach as is.
		if (fileInfo.Length < bytes)
		{
			var attachment = new Attachment(fileNameAndPath);
			return attachment;
		}
		byte[] fileBytes = File.ReadAllBytes(fileNameAndPath);
		using (var memoryStream = new MemoryStream())
		{
			string fileName = Path.GetFileName(fileNameAndPath);
			using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create))
			{
				ZipArchiveEntry zipArchiveEntry = zipArchive.CreateEntry(fileName, CompressionLevel.Optimal);
				using (var streamWriter = new StreamWriter(zipArchiveEntry.Open()))
				{
					streamWriter.Write(Encoding.Default.GetString(fileBytes));
				}
			}
			var attachmentStream = new MemoryStream(memoryStream.ToArray());
			string zipname = $"{Path.GetFileNameWithoutExtension(fileName)}.zip";
			var attachment = new Attachment(attachmentStream, zipname, MediaTypeNames.Application.Zip);
			return attachment;
		}
	}
