    [TypeConverter(typeof(Class1Converter))]
    public class Class1
    {
        public int Id { get; set; }
        public NamingConvention Naming { get; set; }
    }
    public enum NamingConvention
    {
        Name1 = 1,
        Name2,
        Name3,
        Name4
    }
