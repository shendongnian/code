    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create 1MM ServiceA...");
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                var o = new ServiceA();
                var obj = o.GetObject();
            }
            sw.Stop();
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine();
            Console.WriteLine("Create 1MM ServiceB...");
            sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                var o = new ServiceB();
                var obj = o.GetObject();
            }
            sw.Stop();
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine();
            Console.WriteLine("Create 1MM GenericServiceA...");
            sw= new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                var o = new GenericServiceBase();
                var obj = o.GetObject<ServiceA>();
            }
            sw.Stop();
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine();
            Console.WriteLine("Create 1MM GenericServiceB...");
            sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000000; i++)
            {
                var o = new GenericServiceBase();
                var obj = o.GetObject<ServiceB>();
            }
            sw.Stop();
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine();
        }
    }
    class GenericServiceBase
    {
        public virtual InstanceBase GetObject<T>()
            where T : ServiceBase
        {
            var v = (ServiceBase)Activator.CreateInstance(typeof(T), new object[] { });
            return v.GetObject();
        }
    }
    class ServiceBase
    {
        public virtual InstanceBase GetObject() { return null; }
    }
    class ServiceA : ServiceBase
    {
        public override InstanceBase GetObject()
        {
            var v = new InstanceA();
            v.Method();
            return v;
        }
    }
    class ServiceB : ServiceBase
    {
        public override InstanceBase GetObject()
        {
            var v = new InstanceB();
            v.Method();
            return v;
        }
    }
    class InstanceBase
    {
        public virtual void Method() { }
    }
    class InstanceA : InstanceBase
    {
        public override void Method() { }
    }
    class InstanceB : InstanceBase
    {
        public override void Method() { }
    }
