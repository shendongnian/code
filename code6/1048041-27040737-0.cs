    using System;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                var childObject = new ChildClass();
    
                childObject.MethodA();
                childObject.MethodB();
                childObject.MethodC();
    
                Console.ReadLine();
            }
        }
    
        class ParentClass 
        {
            public void MethodA()
            {
                //Do stuff
                _MethodB();
            }
    
            private void _MethodB()
            {
                Console.WriteLine("[B] I am called from parent.");
            }
    
            public virtual void MethodB()
            {
                _MethodB();
            }
    
            public void MethodC()
            {
                Console.WriteLine("[C] I am called from parent.");
            }
        }
    
        class ChildClass : ParentClass
        {
            public override void MethodB()
            {
                Console.WriteLine("[B] I am called from chield.");
            }
    
            public new void MethodC()
            {
                Console.WriteLine("[C] I am called from chield.");
            }
        }
    }
