    public class BaseEntity
    {
        private static readonly string[] fields = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.GetProperties().Select(p => p.Name).Where(name => !name.Equals("Fields")).ToArray();
        public static IEnumerable<string> Fields { get { return fields; } }
        public object field1 { get; set; }
    }
    public class ChildEntity : BaseEntity
    {
        private static readonly string[] fields = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.GetProperties().Select(p => p.Name).Where(name => !name.Equals("Fields")).ToArray();
        public static IEnumerable<string> Fields { get { return fields; } }
        public object field2 { get; set; }
    }
	
    public class GrandChildEntity : ChildEntity
    {
        private static readonly string[] fields = System.Reflection.MethodInfo.GetCurrentMethod().DeclaringType.GetProperties().Select(p => p.Name).Where(name => !name.Equals("Fields")).ToArray();
        public static IEnumerable<string> Fields { get { return fields; } }
        public object field3 { get; set; }
    }
