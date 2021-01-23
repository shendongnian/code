    class Program
        {
            static void Main(string[] args)
            {
                MyType a = new MyType() { id = 10 };
                MyType b = new MyType() { id = 20 };
                MyType c = new MyType() { id = 30 };
    
                List<MyType> testList = new List<MyType>();
    
                testList.Add(a);
                testList.Add(b);
    
                Console.WriteLine(testList.Contains(a)); // <= Will return true
                Console.WriteLine(testList.Contains(c)); // <= Will return false
    
                Console.WriteLine(testList.IndexOf(a)); // <= will return 0 : the index of object a
       
                Console.ReadKey();    
            }   
        }
    
        // A simple class
        class MyType
        {
            private int ID;
    
            public int id
            {
                get { return ID; }
                set { ID = value; }
            }
         }
