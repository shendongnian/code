    void Main()
    {
    	int x = 5;
    	Console.WriteLine (x);
    	Test(x);
    	Console.WriteLine (x);
    	
    	MyClass c = new MyClass();
    	c.Name = "Jay";
    	Console.WriteLine (c.Name);
    	TestClass(c);
    	Console.WriteLine (c.Name);
    }
    
    private void Test(int a){
     a += 5;
    }
    
    private void TestClass(MyClass c){
     c.Name = "Jeroen";
    }
    
    public class MyClass {
     public String Name {get; set; }
    }
