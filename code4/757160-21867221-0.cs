    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    
    ////////
    ////////
    /// Multiple Inheritance With Interfaces
    
    public interface Interface1
    {
        void func1();
        void fun();
    }
    
    public interface Interface2
    {
        void func2();
        void fun();
    }
    
    public class MyTestBaseClass : Interface1, Interface2
    {
        void Interface1.func1()
        {
            Console.WriteLine("From MyInterface1 Function()");
            return;
        }
    
    
        void Interface2.func2()
        {
            Console.WriteLine("From MyInterface2 Function()");
            return;
        }
    
        void Interface1.fun()
        {
            Console.WriteLine("fun1()");
        }
    
        void Interface2.fun()
        {
            Console.WriteLine("fun2()");
        }
    
    
        public static void Main()
        {
            MyTestBaseClass myclass = new MyTestBaseClass();
            ((Interface1)myclass).func1();
            ((Interface2)myclass).func2();
        }
    
    }
