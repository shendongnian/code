    [Serializable]
    public class MyClass
    {
	    public int MyProperty { get; set; }
    }
    
    var myClass = new MyClass { MyProperty = 1 };
 
    byte[] bytes = null;
    using (var ms = new MemoryStream())
    {
	    var bf = new BinaryFormatter();
	    bf.Serialize(ms, myClass);
	    bytes = ms.ToArray();
    }
