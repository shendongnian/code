    public static System.IO.MemoryStream Serialize(object _Object)
    {
    	System.IO.MemoryStream _Return = new System.IO.MemoryStream();
    	Serialize(ref _Return, _Object);
    	return _Return;
    }
    
    public static void Serialize(ref System.IO.Stream Stream, object _Object)
    {
    	BinaryFormatter BF = new BinaryFormatter();
    	BF.Serialize(Stream, _Object);
    }
    
    public static objType Deserialize<objType>(ref System.IO.Stream Stream)
    {
    	object _Return = null;
    	Stream.Seek(0, SeekOrigin.Begin);
    	BinaryFormatter BF = new BinaryFormatter();
    	_Return = BF.Deserialize(Stream);
    	return (objType)_Return;
    }
