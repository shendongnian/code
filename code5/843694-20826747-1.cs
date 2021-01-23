    namespace ConsoleApplication1
    {
        public struct MyClass
        {
            public string MyData {get;set;}
           
    
            // Constructor. 
            public MyClass(string obj1):this()
            {
                this.MyData = obj1;
            }
    
           
            public static MyClass operator +(MyClass c1, string var3)
            {
                return new MyClass(var3);
            }
           
            public override string ToString()
            {
                return (System.String.Format("{0} ", this.MyData));
            }
        }
       
        [System.Runtime.InteropServices.GuidAttribute("D36900FE-8902-4ED8-B961-DE5B3F3273AC")]
        class Program
        {
            static void Main(string[] args)
            {
               MyClass obj1 = new MyClass();
                obj1 += "Hello";               
                Console.ReadKey();
            }
        }
    }
