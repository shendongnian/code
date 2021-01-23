    public class MyClass
    {
        [TypeConverter(typeof(MyTypeConverter))]
        public string MyText { get; set; }
    }
