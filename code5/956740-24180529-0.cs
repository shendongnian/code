    class Program
    {
        //instantiate MyNewClass
        var myNewClass = new MyNewClass();
        static void Main(string[] args)
        {
            Program p = new Program();
            var myString = p.NonStaticMethod();
        }
    
        public string NonStaticMethod()
        {
            //use the instance of MyNewClass
            return myNewClass.MyStringMethod(); //Cannot call non static method
        }
    }
    
    class MyNewClass
    {
        public string MyStringMethod()
        {
            return "method called";
        }
    }
