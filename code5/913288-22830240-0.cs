    using System;
    namespace ConsoleStuff
    {
        public abstract class MyAbstractClass
        {
            public abstract void DoSomethingAbs();
        
            public void DoSomethingElse()
            {
                Console.WriteLine("Do something general...");
            }
            public static void TakeABreak()
            {
                Console.WriteLine("Take a break");
            }
        }
        class MyImplementation : MyAbstractClass
        {
            public override void DoSomethingAbs()
            {
                Console.WriteLine("Do something Specific...");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Static method; no instance required
                MyAbstractClass.TakeABreak();
            
                var inst = new MyImplementation();
                inst.DoSomethingAbs();  // Required implementation in subclass
                inst.DoSomethingElse(); // Use method from the Abstract directly
                Console.ReadKey();
            }
        }
    }
