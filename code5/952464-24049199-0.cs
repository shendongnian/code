    String data = "Hello! My name it Inigo Montoya.";
    using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
    {
    	using (StreamReader reader = new StreamReader(stream))
    	{
    		// Do your parsing here using the standard StreamReader methods.
    		// They should be fairly comparable to StringReader.
    
    		// When all done, reset stream position to the beginning.
    		stream.Seek(0, SeekOrigin.Begin);
    	}
    }
