    class Program
    {
        interface ICallBack<T>
        {
            void SetObject(T obj);
        }
        class CallBackUser<T>
        {
            public dynamic CB { get; set; }
        }
        class CB<T> : ICallBack<T>
        {
            public void SetObject(T obj)
            {
                Console.WriteLine("Works");
            }
        }
        static Type GetMyTypeThroughReflection()
        {
            return typeof (int);
        }
        static void Main(string[] args)
        {
            Type t = GetMyTypeThroughReflection();
            Type genericClass = typeof(CallBackUser<>);
            Type constructedClass = genericClass.MakeGenericType(t);
            dynamic created = Activator.CreateInstance(constructedClass);
            created.CB = new CB<int>();
            created.CB.SetObject(0);
            Console.ReadKey();
        }
    }
