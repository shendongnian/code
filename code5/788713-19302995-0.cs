    class Program
    {
        static void Main(string[] args)
        {
            SampleClass.Foo<int>(param =>
                {
                });
            var discoveredTypes = new List<Type>
            {
                typeof(DerivedOne),
                typeof(DerivedTwo),
                typeof(DerivedThree)
            };
            foreach (var type in discoveredTypes)
            {
                var methodType = typeof(Program).GetMethods().FirstOrDefault(x => x.Name == "CreateMethod").MakeGenericMethod(type);
                var method = methodType.Invoke(null, null);
                var staticMethod = typeof(SampleClass).GetMethods().FirstOrDefault(x => x.Name == "Foo").MakeGenericMethod(type);
                staticMethod.Invoke(null, new object[] { method });
            }
            Console.ReadKey();
        }
        public static Action<T> CreateMethod<T>()
        {
            return new Action<T>((param) =>
                {
                    Console.WriteLine("This is being invoked with type: " + typeof(T).Name);
                });
        }
    }
    public abstract class AbstractClass { }
    public class DerivedOne : AbstractClass { }
    public class DerivedTwo : AbstractClass { }
    public class DerivedThree : AbstractClass { }
    public class SampleClass
    {
        public static void Foo<TGenericType>(Action<TGenericType> setupMethod)
            where TGenericType : new()
        {
            TGenericType instance = new TGenericType();
            setupMethod(instance);
        }
    }
