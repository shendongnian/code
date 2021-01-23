    [AttributeUsage(AttributeTargets.Method)]
    public class MyAttribute : Attribute
    {
        ...
        public MyAttribute(string name, DateTime lastChanged, CustomEnum reason)
        {
            ... 
