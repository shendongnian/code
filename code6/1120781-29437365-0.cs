    // "2.bar\r\n" will be replaced by "!!!!!\r\n"
    File.WriteAllText("test.txt", 
    @"1.foo
    2.bar
    3.fake");
    // open inputStream for StreamReader, and open outputStream for StreamWriter
    using (var inputStream = File.Open("test.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    using (var reader = new StreamReader(inputStream))
    using (var outputStream = File.Open("test.txt", FileMode.Open, FileAccess.Write, FileShare.Read))
    using (var writer = new StreamWriter(outputStream))
    {
    	var position = 0L; // track the reading position
    	var newLineLength = Environment.NewLine.Length;
    	while (!reader.EndOfStream)
    	{
    		var line = reader.ReadLine();
    		// your particular conditions here.
    		if (line.StartsWith("2."))
    		{
    			// seek line start position
    			outputStream.Seek(position, SeekOrigin.Begin);
    			// replace by something, 
                // but the length should be equal to original in this case.
    			writer.WriteLine(new String('!', line.Length));
    		}
    		position += line.Length + newLineLength;
    	}
    }
    /* as a result, test.txt will be:
    1.foo
    !!!!!
    3.fake
    */
