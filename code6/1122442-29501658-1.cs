	using (var stream = new FileStream(_caminho, FileMode.Append, FileAccess.Write))
	{
		WriteByte(stream, '0');
		WriteString(stream, "foo", Encoding.UTF8);
	}
	private void WriteByte(Stream stream, byte byteToWrite)
	{
		stream.Write(new[] { byteToWrite }, 0, 1);
	}
	private void WriteString(Stream stream, string stringToWrite, Encoding encoding)
	{
		var charBuffer = encoding.GetBytes(stringToWrite);
		stream.Write(charBuffer, 0, charBuffer.Length);
	}
