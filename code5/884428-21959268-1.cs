    namespace Classes
    {
        class Program
        {
            static void Main(string[] args)
            {
               MyMethods myMethod = new MyMethods();
               MyVariableClass myVarClass = new MyVariableClass();
    
                string something = "something";
                string nothingHere = null;
    
                myMethod.DoSomeStuff(myVarClass, something, nothingHere);
    
                //I need to call MyVariable here
                //Or be able to access it's values assigned in the MyMethod Class.
    
                Console.Write(myVarClass.MyVariable);
                Console.ReadKey();
            }
        }
    }
