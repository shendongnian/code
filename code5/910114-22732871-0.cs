    void Main()
    {
    	var stream = new MemoryStream();
    	var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    	formatter.Serialize(stream, new Foo { bar = new Bar { barInt = 2 } });
    	
    }
    
    // Define other methods and classes here
    [Serializable]
    public class Foo { public Bar bar; }
    
    public class Bar { public int barInt; }
