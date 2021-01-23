    class Program
    {
        static void Main(string[] args)
        {
            Entity tt = default(Entity);
            Test tester = default(Test);
            SetProperty(out tester, 5);
            SetProperty(out tt, "Test7");
            Console.WriteLine(tester);
            Console.WriteLine(tt);
            Console.ReadLine();
        }
        public static T Cast<T>(T target, object Source)
        {
            return (T)Source;
        }
        public static void SetProperty<T>(out T target, object source)
        {
            Type t = typeof(T);
            Type sourceType = source.GetType();
            if (t.IsEnum)
            {
                Type enumType = t.GetEnumUnderlyingType();
                if (Type.Equals(sourceType, enumType))
                {
                    target = (T)Cast(Activator.CreateInstance(enumType), source);
                    return;
                }
                if (Type.Equals(sourceType, typeof(string)))
                {
                    Array names = t.GetEnumValues();
                    foreach (var name in names)
                    {
                        if (name.ToString() == source.ToString())
                        {
                            target = (T)name;
                            return;
                        }
                    }
                }
            }
            target = default(T);
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
