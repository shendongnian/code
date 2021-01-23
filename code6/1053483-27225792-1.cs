    public class MyClass
    {
        public String TestProperty { get; set; }
    }
    
    public class TestClass
    {
        public TestClass()
        {
            var myClass = new MyClass();
            myClass.TestProperty = "First Modification";
            MyFunction(myClass);
            Console.WriteLine(myClass.TestProperty); // Output: "First Modification"
            MyRefFunction(ref myClass);
            Console.WriteLine(myClass.TestProperty); // Output: "Third Modification"
        }
        void MyFunction(MyClass myClass)
        {
            myClass = new MyClass() { TestProperty = "Second Modification"};
        }
    	
    	void MyRefFunction (ref MyClass myClass)
    	{
    	    myClass = new MyClass() { TestProperty = "Third Modification"};
    	}
    }
