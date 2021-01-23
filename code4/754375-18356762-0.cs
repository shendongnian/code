    class MyClass
    {
        public virtual void Foo()
        {
            if (true)
                 throw new System.Exception();
            }
        }
    }
    
    class MyDerivedClass : MyClass
    {   
        public override void Foo() 
        {
            if (true)
                throw new ArgumentNullException();
            }
        }           
    }
    
    
    public class Program
    {
        public static void Main()
        {
            try
            {
                // a factory creating the correct 
                // MyClass derived instance
                var myClass = someFactory.Create();
                myClass.Foo();
            }
            catch (Exception)
            {
                // will work.
            }
        }
    }
