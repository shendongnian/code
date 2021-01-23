    public class MyClass
    {
        [NotMapped]
        public String Str1 { get; set; } // this property will not be a column in MyClass table
        public String Str2 { get; set; }
        public String Str3 { get; set; }
    }
