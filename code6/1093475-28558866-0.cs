    class Program
    {
        static void Main(string[] args)
        {
            Test root = new Test
            {
                Property1 = new Test { Value = 3 },
                Property2 = new Test { Value = 4 },
                Property3 = new Test { Property1 = new Test { Value = 4} }
            };
            int testValue1;
            if (root.TryGetData<int>(out testValue1,"Property1","Value"))
            {
                Console.WriteLine(testValue1);
            }
            int testValue2;
            if (root.TryGetData<int>(out testValue2, "Property2","Property1","Value" ))
            {
                Console.WriteLine("Would be bad if this would enter here");
            }
            if (root.TryGetData<int>(out testValue2, "Property3", "Property1", "Value"))
            {
                Console.WriteLine(testValue2);
            }
        }
    }
    class Test
    {
        public Test Property1 { get; set; }
        public Test Property2 { get; set; }
        public Test Property3 { get; set; }
        public int Value { get; set; }
    }
    public static class ExtensionMethods
    {
        public static bool TryGetData<T>(this object theObject, out T value, params string[] path)
        {
            object cursor = theObject;
            for (int i = 0; i < path.Length; i++)
            {
                if (cursor == null)
                {
                    value = default(T);
                    return false;
                }
                Type t = cursor.GetType();
                cursor = t.GetProperty(path[i]).GetValue(cursor);
            }
            value = (T)cursor;
            return true;
        }
    }
