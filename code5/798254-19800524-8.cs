    using (FileStream)
	{
		FileStream.Seek(rangeStartIndex, SeekOrigin.Begin);
		int bytesRemaining = Convert.ToInt32(rangeEndIndex - rangeStartIndex) + 1;
		byte[] buffer = new byte[_bufferSize];
		while (bytesRemaining > 0)
		{
			int bytesRead = FileStream.Read(buffer, 0, _bufferSize < bytesRemaining ? _bufferSize : bytesRemaining);
			response.OutputStream.Write(buffer, 0, bytesRead);
			bytesRemaining -= bytesRead;
		}
	}
