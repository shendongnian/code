    static class Program
    {
        static void Main()
        {
            int a = 1;
            Console.WriteLine("a.IsDefaultValue() : " + a.IsDefaultValue());
            a = 0;
            Console.WriteLine("a.IsDefaultValue() : " + a.IsDefaultValue());
            object obj = new object();
            Console.WriteLine("obj.IsDefaultValue() : " + obj.IsDefaultValue());
            obj = null;
            Console.WriteLine("obj.IsDefaultValue() : " + obj.IsDefaultValue());
            int? b = 1;
            Console.WriteLine("b.IsDefaultValue() : " + b.IsDefaultValue());
            b = null;
            Console.WriteLine("b.IsDefaultValue() : " + b.IsDefaultValue());
            Console.ReadKey(true);
        }
        static bool IsDefaultValue<T>(this T value)
        {
            if (ReferenceEquals(value, null))
            {
                return true;
            }
            var t = value.GetType();
            if (t.IsValueType)
            {
                return value.Equals(Activator.CreateInstance(value.GetType()));
            }
            return false;
        }
    }
