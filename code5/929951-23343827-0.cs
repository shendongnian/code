	private Dictionary<string, StreamWriter>  _writers;  // Consider using a thread-safe dictionary
	void  WriteContent(string file, string content)
		{
		StreamWriter  writer;
		if (_writers.TryGetValue(file, out writer))
			lock (writer)
				writer.Write(content);
		// Else handle missing writer
		}
