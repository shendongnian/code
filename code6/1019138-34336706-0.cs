    namespace ConsoleApplication8
    {
    using System;
    using Castle.DynamicProxy;
    internal interface IFreezable
    {
        bool IsFrozen { get; }
        void Freeze();
    }
    public class Pet : IFreezable
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual bool Deceased { get; set; }
        bool _isForzen;
        public bool IsFrozen => this._isForzen;
        public void Freeze()
        {
            this._isForzen = true;
        }
        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}, Deceased: {2}", Name, Age, Deceased);
        }
    }
    [Serializable]
    public class FreezableObjectInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            IFreezable obj = (IFreezable)invocation.InvocationTarget;
            if (obj.IsFrozen && invocation.Method.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase))
            {
                throw new NotSupportedException("Target is frozen");
            }
            invocation.Proceed();
        }
    }
    public static class FreezableObjectFactory
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator(new PersistentProxyBuilder());
        public static TFreezable CreateInstance<TFreezable>() where TFreezable : class, new()
        {
            var freezableInterceptor = new FreezableObjectInterceptor();
            var proxy = _generator.CreateClassProxy<TFreezable>(freezableInterceptor);
            return proxy;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var rex = FreezableObjectFactory.CreateInstance<Pet>();
            rex.Name = "Rex";
            Console.WriteLine(rex.ToString());
            Console.WriteLine("Add 50 years");
            rex.Age += 50;
            Console.WriteLine("Age: {0}", rex.Age);
            rex.Deceased = true;
            Console.WriteLine("Deceased: {0}", rex.Deceased);
            rex.Freeze();
            try
            {
                rex.Age++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oups. Can't change that anymore");
            }
            Console.WriteLine("--- press enter to close");
            Console.ReadLine();
        }
    }
    }
