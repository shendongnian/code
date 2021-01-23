    [AttributeUsage(AttributeTargets.Property)]
    public class RecursableAttribute : Attribute { }
    
    public class Car
    {
        public int CarId { get; set;}
        public string Description { get; set;}
        [Recursable]
        public Engine Engine { get; set;}
    }
    ...
    var properties =
        from p1 in obj.GetType().GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public)
        from p2 in p1.GetCustomAttributes(typeof(RecursableAttribute), true).Length > 0
            ? p1.PropertyType.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public).DefaultIfEmpty()
            : new PropertyInfo[] { null }
        select new { OuterProperty = p1, InnerProperty = p2 };
