    using System;
    using System.Threading;
    interface I<out T>
    {
        void Print();
    }
    interface J<out T> : I<T> { }
    class A : I<C>
    {
        void I<C>.Print()
        {
            Console.WriteLine("A: I<C>");
        }
    }
    class B {}
    class C : B { }
    class D1 : I<A>
    {
        void I<A>.Print()
        {
            Console.WriteLine("D1: I<A>");
        }
    }
    class D2 : D1, J<B>
    {
        void I<B>.Print()
        {
            Console.WriteLine("D2: I<B>");
        }
    }
    class D3 : D1, J<C>
    {
        void I<C>.Print()
        {
            Console.WriteLine("D3: I<C>");
        }
    }
    class D4 : A, J<B>
    {
        void I<B>.Print()
        {
            Console.WriteLine("D4: I<B>");
        }
    }
    static class Program
    {
        static void f<T>(J<T> obj)
        {
            f((I<T>)obj);
        }
        static void f<T>(I<T> obj)
        {
            obj.Print();
        }
        static void Main()
        {
            f<A>(new D2());
            f(new D2());
            f(new D3());
            f(new D4());
            f<C>(new D4());
            Console.ReadKey();
        }
    }
