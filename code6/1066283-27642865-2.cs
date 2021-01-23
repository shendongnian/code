    class Program
    {
        static void Main(string[] args)
        {
            Entity tt = default(Entity);
            Test tester = default(Test);
            tester = SetProperty(tester, 5);
            tt = SetProperty(tt, "Test7");
            Console.WriteLine(tester);
            Console.WriteLine(tt);
            Console.ReadLine();
        }
        public static T Cast<T>(T target, object Source)
        {
            return (T)Source;
        }
        public static dynamic SetProperty<T>(T target, object source)
        {
            Type t = typeof(T);
            Type sourceType = source.GetType();
            if (t.IsEnum)
            {
                Type enumType = t.GetEnumUnderlyingType();
                if (Type.Equals(sourceType, enumType))
                {
                    return (T)Cast(Activator.CreateInstance(enumType), source);
                }
                if (Type.Equals(sourceType, typeof(string)))
                {
                    Array names = t.GetEnumValues();
                    foreach (var name in names)
                    {
                        if (name.ToString() == source.ToString())
                        {
                            return (T)name;
                        }
                    }
                }
                return default(T);
            }
            return null;
        }
        public enum Entity
        {
            Test5,
            Test7,
            Test8
        }
        public enum Test : int
        {
            Test1 = 1,
            Test2 = 5,
            Test4 = 7
        }
    }
