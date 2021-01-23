	using (var stream = new FileStream(_caminho, FileMode.Append, FileAccess.Write))
	{
		WriteByte(stream, '0');
		WriteString(stream, "foo", Encoding.UTF8);
	}
	private void WriteByte(Stream stream, byte byteToWrite)
	{
		stream.Write(new[] { byteToWrite });
	}
	private void WriteString(Stream stream, string stringToWrite, Encoding encoding)
	{
		stream.Write(encoding.GetBytes(stringToWrite));
	}
