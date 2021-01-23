    public class MyClass
    {
    	public string Property1 { get; set; }
    	public int Property2 { get; set; }
    	public string Property3 { get; set; }
    }
    
    var myClass1 = new MyClass() { Property1 = "a" };
    var myClass2 = new MyClass() { Property1 = "a", Property2 = 1 };
    var myClass3 = new MyClass() { Property1 = "a", Property2 = 1, Property3 = "b" };
    var myClass4 = new MyClass() { Property1 = "a", Property3 = "b" };
