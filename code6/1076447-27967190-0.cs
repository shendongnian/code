    public static class Utilities
    {
        public static ValueType FooStruct(this ValueType value)
        {
            //put your code here
            return default(ValueType);
        }
        public static object FooClass(this object value)
        {
            //put your code here
            return null;
        }
        public static T FooStruct<T>(this T value) where T: struct
        {
            return (T) FooStruct(value);
        }
        public static T FooClass<T>(this T value) where T: class
        {
            return (T) FooClass(value);
        }
    }
    public class Program
    {
        class TestClass
        {
            public TestStruct StructField;
        }
        struct TestStruct
        {
            int x;
            int y;
        }
        public static void Main()
        {
            var x = new TestClass();
            Type type = x.GetType();
            foreach (var fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                var val = fieldInfo.GetValue(x);
                object obj = fieldInfo.FieldType.IsValueType ? ((ValueType)val).FooStruct() : val.FooClass();
                fieldInfo.SetValue(x, obj);
            }
            //Generic call
            var structVar = new TestStruct();
            structVar.FooStruct();
        }
    }
