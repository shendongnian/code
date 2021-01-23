	string sourcePath = "...";
	string destinationPath = "...";
	Encoding sourceEncoding = Encoding.UTF16;
	Encoding destinationEncoding = Encoding.UTF8;
	char[] readBuffer = new char[1024];
	int bytesRead;
	using (var writer = new StreamWriter(destinationPath, false, destinationEncoding))
	{
		using (var reader = new StreamReader(sourcePath, sourceEncoding)(
		{
			while ((bytesRead = reader.Read(readBuffer, 0, readBuffer.Length)) > 0)
			{
				writer.Write(buffer, 0, bytesRead);
			}
		}
	}
