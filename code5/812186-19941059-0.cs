    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace VirtualMethodCalledFromConstructor
    {
        class Program
        {
            static void Main(string[] args)
            {
                Derived d = new Derived();
                Console.ReadLine();
            }
        }
    
        public class Base
        {
            public Base()
            {
                Console.WriteLine("Base::Base()");
                virt();
            }
            public virtual void virt()
            {
                Console.WriteLine("Base::virt()");
            }
        }
        public class Derived : Base
        {
            public Derived()
            {
                Console.WriteLine("Derived::Derived()");
                virt();
            }
            public virtual void virt()
            {
                Console.WriteLine("Derived::virt()");
            }
        }
    }
