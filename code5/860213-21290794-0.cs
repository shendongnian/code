    public class BaseEntity
    {
        protected static readonly string[] fields = { "field1" };
        public static IEnumerable<string> Fields
        {
            get { return fields; }
        }
    }
    public class ChildEntity : BaseEntity
    {
        protected static readonly string[] fields = { "field2" } ;
        public static IEnumerable<string> Fields
        {
            get { return BaseEntity.Fields.Concat(fields); }
        }
    }
    // Result:
    // BaseEntity.Fields == { "field1" };
    // ChildEntity.Fields == { "field1", "field2" };
