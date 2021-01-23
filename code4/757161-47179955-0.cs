    public class Class1
    {
        public void Method1()
        {
            Console.write("Class1: Method1");
        }
    }
    public class Class2
    {
        public void Method2()
        {	
	        Console.write("Class2: Method2");      
        }
     }
 
    public class MultipleClass
    {
        private Class1 class1 = new Class1();
        private Class2 class2 = new Class2();
        public void Method1()
        {
            class1.Method1();
        }
        public void Method2()
        {
            class2.Method2();
        }
    }
