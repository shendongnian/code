    using System;
    
    namespace ThirdParty
    {
        public interface ISomeInterface
        {
            string MyProperty { get; }
        }
    
        public static class Factory
        {
            public static ISomeInterface create() { return new MyClass(); }
        }
    
        internal class MyClass : ISomeInterface
        {
            internal MyClass()
            {
                Locker = new object();
            }
    
            public object Locker { get; private set; }
    
            private string _myProperty;
            public string MyProperty
            {
                get
                {
                    lock (Locker)
                    {
                        if (_myProperty == null)
                            MyProperty = "foo";
                        return _myProperty;
                    }
                }
    
                private set
                {
                    _myProperty = value;
                }
            }
        }
    }
---
    using System;
    using System.Linq;
    
    using System.Reflection;
    using System.Threading;
    using ThirdParty;
    
    namespace InternalLocker
    {
        class Program
        {
            static void Main(string[] args)
            {
                test1();
                test2();
            }
    
            static void test1()
            {
                ISomeInterface thing = Factory.create();
                string foo = thing.MyProperty;
                assert(foo == "foo");
            }
    
            static void test2()
            {
                ISomeInterface thing = Factory.create();
                // use reflection to find the public property
                Type type = thing.GetType();
                PropertyInfo propertyInfo = type.GetProperty("Locker");
                // get the property value
                object locker = propertyInfo.GetValue(thing, null);
                // use the property value
                if (Monitor.TryEnter(locker))
                {
                    string foo = thing.MyProperty;
                    Monitor.Exit(locker);
                    assert(foo == "foo");
                }
                else
                    assert(false);
            }
    
            static void assert(bool b)
            {
                if (!b)
                    throw new Exception();
            }
        }
    }
