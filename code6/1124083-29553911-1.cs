    public class MyClass
    {
    	public SomeProperty MyProperty { get; set; }
    }
    
    
    static void Main(string[] args)
    {
    	MyClass myClass = new MyClass();
    
    
    	string case1 = Util.NameOf(() => myClass.MyProperty);		//Case1 when an instance is available 250x
    	string case2 = Util.NameOf(() => (null as MyClass).MyProperty);	//Case2 when no instance is available 175x
    	string case3 = Util.NameOf((MyClass c) => c.MyProperty);		//Case3 when no instance is available 330x
        string caseTest = "MyProperty";     //Test case 1x
    }
