    public class SomeBaseClass {
        public string someProperty {
            set {
                Console.WriteLine(string.Format("someProperty called on {0} with {1}", this, value ) );
            }
        }
    }
    public class Foo : SomeBaseClass {
    }
    public class Bar : SomeBaseClass {
    }
    public class Baz : SomeBaseClass {
    }
    public static class SomeMethods {
        public static T SomeMethod<T>() where T : SomeBaseClass, new() {
            return new T();
        }
    }
    class Program
    {
        public static void Example1() {
            string someValue = "called from Example1";
            SomeMethods.SomeMethod<Foo>().someProperty = someValue;
            SomeMethods.SomeMethod<Bar>().someProperty = someValue;
            SomeMethods.SomeMethod<Baz>().someProperty = someValue;
        }
        public static void Example2() {
            string someValue = "called from Example2";
            Type[] types = new Type[]{
                typeof(Foo), typeof(Bar), typeof(Baz), //...
            };
            foreach (Type type in types) {
                // Here's how:
                System.Reflection.MethodInfo genericMethodInfo = typeof(SomeMethods).GetMethod("SomeMethod");
                System.Reflection.MethodInfo methodInfoForType = genericMethodInfo.MakeGenericMethod(type);
                var someBase = (SomeBaseClass) methodInfoForType.Invoke(null, new object[] { });
                someBase.someProperty = someValue;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Example1");
            Example1();
            Console.WriteLine("Example2");
            Example2();
            Console.ReadKey();
        }
    }
