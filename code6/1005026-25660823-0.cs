    internal class Program
    {
        private static Func<object, string> somePropFunc;
        private static void Main(string[] args)
        {
            //Create instance somehow
            Type type = typeof(Hidden);
            object hiddenInstance = Activator.CreateInstance(type);
            //Cache the delegate in static field, and use it any number of times
            somePropFunc = GetSomePropAccessorMethod();
            for (int i = 0; i < 100; i++)
            {
                // Access Hidden.SomeProp
                Console.WriteLine(somePropFunc(hiddenInstance));
            }
        }
        private static Func<object, string> GetSomePropAccessorMethod()
        {
            Type type = typeof(Hidden);
            PropertyInfo prop = type.GetProperty("SomeProp");
            var parameter = Expression.Parameter(typeof(object), "hidden");
            var castHidden = Expression.TypeAs(parameter, type);
            var propertyAccessor = Expression.Property(castHidden, prop);
            return Expression.Lambda<Func<object, string>>(propertyAccessor, parameter).Compile();
        }
    }
    internal class Hidden
    {
        public string SomeProp
        {
            get
            {
                return "Some text";
            }
        }
    }
