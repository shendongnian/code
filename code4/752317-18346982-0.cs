    private CookieContainer CopyContainer(CookieContainer container)
    {
    	MemoryStream stream = new MemoryStream();
    	BinaryFormatter formatter = new BinaryFormatter();
    	formatter.Serialize(ms, container);
    	ms.Seek(0, SeekOrigin.Begin);
    	return (CookieContainer)formatter.Deserialize(ms);
    }
