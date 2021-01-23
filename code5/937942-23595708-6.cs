    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    sealed class MethodIDAttribute : Attribute
    {
        public int ID { get; private set; }
        public MethodIDAttribute(int id)
        { this.ID = id; }
    }
    public class TestClass
    {
        public static Dictionary<int, MethodInfo> MethodIDs = new Dictionary<int, MethodInfo>();
        static TestClass()
        {
            MethodInfo[] mi = typeof(TestClass).GetMethods();
            foreach (MethodInfo info in mi)
            {
                if (info.Name == "ToString" || info.Name == "Equals" || info.Name == "GetHashCode" || info.Name == "GetType")
                { continue; }
                int id = ((MethodIDAttribute)info.GetCustomAttribute(typeof(MethodIDAttribute))).ID;
                MethodIDs.Add(id, info);
            }
        }
        [MethodID(123456)]
        public int Double(int i)
        {
            return i * 2;
        }
    }
    public static class Constants
    {
        public static class TestClass
        {
            public static int Double = 123456;
        }
    }
    public class ExampleCaller
    {
        public int SomeMethod()
        {
            TestClass tc = new TestClass();
            return (int)TestClass.MethodIDs[Constants.TestClass.Double].Invoke(tc, new object[] { 10 });
        }
    }
