    class MyClass
    {
        public virtual void Foo()
        {
            if (true)
                 throw new ArgumentNullException();
            }
        }
    }
    
    class MyDerivedClass : MyClass
    {   
        public override void Foo() 
        {
            if (true)
                throw new Exception();
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
            catch (ArgumentNullException)
            {
                // won't work since the subclass 
    			// violates LSP
            }
        }
    }
