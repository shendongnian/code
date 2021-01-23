    class BaseClass<T>
    {
        public static void Close()
        {
            Console.WriteLine("Closing " + typeof(T).Name);
        }
    }
    class Derived1 : BaseClass<int>  { }
    class Derived2 : BaseClass<double> { }
