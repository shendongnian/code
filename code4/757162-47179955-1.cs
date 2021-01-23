    public class Class1
    {
        public void Method1()
        {
            Console.write($"Class1: Method1, MyInt: {MyInt}");
        }
        public int MyInt { get; set; }
    }
    public class Class2
    {
        public void Method2()
        {	
	        Console.write($"Class2: Method2, MyInt: {MyInt}");      
        }
        public int MyInt { get; set; }
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
 
        private int _myInt;
        public int MyInt
        {
            get { return this._myInt; }
            set
            {
                this._myInt = value;
                class1.MyInt = value;
                class2.MyInt = value;
            }
        }
    }
