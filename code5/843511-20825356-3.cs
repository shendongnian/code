    public class TestClassA {
        public string SomeString { get; set; }
        public int SomeInt { get; set; }
        public TestClassB ClassB { get; set; }
    }
    public class TestClassB {
        public string AnotherString { get; set; }
    }
    public class Program {
        private static void Main(string[] args) {
            var items = new List<TestClassA>();
            for (int i = 0; i < 9; i++) {
                items.Add(new TestClassA {
                    SomeString = string.Format("This is outer string {0}", i),
                    SomeInt = i,
                    ClassB = new TestClassB { AnotherString = string.Format("This is inner string {0}", i) }
                });
            }
            var newEnumerable = SelectNew(items, new string[] { "ClassB.AnotherString" });
            foreach (var dict in newEnumerable) {
                foreach (var key in dict.Keys)
                    Console.WriteLine("{0}: {1}", key, dict[key]);
            }
            Console.ReadLine();
        }
        public static IEnumerable<Dictionary<string, object>> SelectNew<T>(IEnumerable<T> items, string[] fields) {
            var newItems = new List<Dictionary<string, object>>();
            foreach (var item in items) {
                var dict = new Dictionary<string, object>();
                foreach (var field in fields)
                    dict[field] = GetPropertyValue(field, item);
                newItems.Add(dict);
            }
            return newItems;
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
