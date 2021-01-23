    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<IShared, Shared>(new PerResolveLifetimeManager());
            container.RegisterType<IChild, Child>();
            container.RegisterType<IParent, Parent>();
            var parent = container.Resolve<IParent>();
            var result = parent.Shared == parent.Child.Shared;
            Console.WriteLine("Result: {0}", result);
            Console.WriteLine("Parent Instance Count: {0}", parent.Shared.InstanceCount);
            Console.WriteLine("Child Instance Count: {0}", parent.Child.Shared.InstanceCount);
        }
    }
    public interface IShared {
        int InstanceCount {get;}
    }
    public interface IChild {
        IShared Shared {get;}
    }
    public interface IParent
    {
        IChild Child {get;}
        IShared Shared { get; }
    }
    public class Child : IChild
    {
        public Child(IShared shared)
        {
            Shared = shared;
        }
        public IShared Shared
        {
            get;
            private set;
        }
    }
    public class Shared : IShared
    {
        private static int _instanceCount = 0;
        private int _myInstanceNumber = 0;
        public Shared()
        {
            _instanceCount++;
            _myInstanceNumber = _instanceCount;
        }
        public int InstanceCount
        {
            get { return _myInstanceNumber; }
        }
    }
    public class Parent : IParent
    {
        public Parent(IChild child, IShared shared)
        {
            Child = child;
            Shared = shared;
        }
        public IChild Child { get; private set; }
        public IShared Shared { get; private set; }
    }
