    class MyCustomAttribute : Attribute
    {
        public Type DeclaringType { get; set; }
    }
    public class Dec
    {
        [MyCustomAttribute(DeclaringType=typeof(Dec))]
        public string Bar { get; set; } 
    }
