    private CookieContainer CopyContainer(CookieContainer container)
    {
    	using(MemoryStream stream = new MemoryStream())
        {
    	    BinaryFormatter formatter = new BinaryFormatter();
    	    formatter.Serialize(stream, container);
    	    stream.Seek(0, SeekOrigin.Begin);
    	    return (CookieContainer)formatter.Deserialize(stream);
        }
    }
