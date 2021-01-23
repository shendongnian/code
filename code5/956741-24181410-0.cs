    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            var myString = p.NonStaticMethod();
        }
    
        public string NonStaticMethod()
        {   
            MyNewClass obj = new MyNewClass();
            if(obj != null)
                return obj.MyStringMethod();
            else
                return "";
        }
    }
    
    class MyNewClass
    {
        public string MyStringMethod()
        {
            return "method called";
        }
    }
