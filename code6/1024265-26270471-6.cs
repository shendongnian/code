        using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                 A a=new A();
                 a.Display();//Parent's Method
                 B b =new B();
                 b.Display();//Child's Method
                 **A ab = new B();
                 ab.Display();//Parent's Method**
                 Console.ReadKey();
                 Parent parent = new Parent();
                 parent.Display();//Parent's Method
                 Child child = new Child();
                 child.Display();//Child's Method
                 **Parent ParentChild = new Child();
                 ParentChild.Display();//Child's Method**
                 Console.ReadKey();
            }
            class A
            {
                public virtual void Display()
                {
                    Console.WriteLine("Parent's Method");
                }
            }
            class B : A
            {
                public void Display()
                {
                    Console.WriteLine("Child's Method");
                }
            }
    
            class Parent
            {
                public virtual void Display()
                {
                    Console.WriteLine("Parent's Method");
                }
            }
            class Child : Parent
            {
                public override void Display()
                {
                    Console.WriteLine("Child's Method");
                }
            }
        }
    }
