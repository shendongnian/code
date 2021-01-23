	byte[] preBuffer;
	using (var memoryStream = new MemoryStream())
	{
		using (BinaryWriter writer = new BinaryWriter(memoryStream))
		{
			writer.Write(filePath);
			writer.Write(fileLength);
			writer.Write(md5Hash);
		}
		preBuffer = memoryStream.ToArray();
	}
	mySocket.SendFile(filePath, preBuffer, null,
		TransmitFileOptions.UseDefaultWorkerThread);
