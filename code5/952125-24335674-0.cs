    interface IChooseGenericArg<T>
    {
        T Choose();
    }
    interface I<out T> 
    {
        string M1();
    }
    class A1 : I<A1>, IChooseGenericArg<A1>
    {
        public string M1()
        {
            return "A1.M1";
        }
        public A1 Choose()
        {
            return this;
        }
    }
    class A2 : A1, I<A2>, IChooseGenericArg<A2>
    {
        public string M1()
        {
            return "A2.M1";
        }
        public new A2 Choose()
        {
            return this;
        }
    }
    static class Program
    {
        static void f<T>(I<T> obj)
        {
            Console.WriteLine(obj.M1());
        }
        static void f2<T>(Func<T> selector, I<T> obj)
        {
            Console.WriteLine(obj.M1());
        }
        static void Main()
        {
            f<A1>(new A1());
            f<A2>(new A2());
            var a2 = new A2();
            f2(() => a2.Choose(), a2);
            var a1 = new A1();
            f2(() => a1.Choose(), a1);
            
            Console.ReadLine();
        }
    }
