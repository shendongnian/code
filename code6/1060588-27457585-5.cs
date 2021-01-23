    var objects = new List<TestObject>();
                objects.Add(new TestObject(1,"Test1"));
                objects.Add(new TestObject(1,"Test2"));
                objects.Add(new TestObject(1,"Test3"));
                objects.Add(new TestObject(2,"Test4"));
                objects.Add(new TestObject(2,"Test5"));
                objects.Add(new TestObject(2,"Test6"));
            List<int> t = objects.GetDistict<int, TestObject>("Zone");
    public static class DistinctExtension
    {
        public static List<T> GetDistict<T,S>(this List<S> source, string name)
        {
            return source.Select(x => (T)x.GetType().GetProperty(name).GetValue(x)).Distinct().ToList();
        }
    }
    
    public class TestObject
    {
        public int Zone { get; set; }
        public string Address { get; set; }
    
        public TestObject(int zone, string address)
        {
            Zone = zone;
            Address = address;
        }
    }
