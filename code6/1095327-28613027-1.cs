    [Serializable]
    public class MyClass
    {
	    public int MyProperty { get; set; }
    }
    
    // On the sending side...
    var myClass = new MyClass { MyProperty = 1 };
 
    byte[] bytes = null;
    using (var ms = new MemoryStream())
    {
	    var bf = new BinaryFormatter();
	    bf.Serialize(ms, myClass);
	    bytes = ms.ToArray();
    }
    // On the receiving side...
    MyClass other = null;
    using (var ms = new MemoryStream(bytes))
    {
	    var bf = new BinaryFormatter();
	    other = (MyClass)bf.Deserialize(ms);
    }
