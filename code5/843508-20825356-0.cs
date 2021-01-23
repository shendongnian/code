    public class TestClassA {
        public string SomeString { get; set; }
        public int SomeInt { get; set; }
        public TestClassB ClassB { get; set; }
    }
    public class TestClassB {
        public string AnotherString { get; set; }
    }
    internal class Program {
        private static void Main(string[] args) {
            var test = new TestClassA { SomeString = "This is a string", SomeInt = 42, ClassB = new TestClassB { AnotherString = "Another one" } };
            Console.WriteLine(GetPropertyValue("ClassB.AnotherString", test));
            Console.ReadLine();
        }
        private static object GetPropertyValue(string property, object o) {
            if (property == null)
                throw new ArgumentNullException("property");
            if (o == null)
                throw new ArgumentNullException("o");
            Type type = o.GetType();
            string[] propPath = property.Split('.');
            var propInfo = type.GetProperty(propPath[0]);
            if (propInfo == null)
                throw new Exception(String.Format("Could not find property '{0}' on type {1}.", propPath[0], type.FullName));
            object value = propInfo.GetValue(o, null);
            if (propPath.Length > 1)
                return GetPropertyValue(string.Join(".", propPath, 1, propPath.Length - 1), value);
            else
                return value;
        }
    }
