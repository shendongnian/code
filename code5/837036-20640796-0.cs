    class Program
    {
        public class Complex1
        {
            public Complex2 Complex2Property { get; set; }
        }
        public class Complex2
        {
            public int IntProperty { get; set; }
        }
        static void Main( string[] args )
        {
            // You must create instances of all properties to avoid a NullReferenceException
            // prior to accessing said properties
            var complex1 = new Complex1();
            complex1.Complex2Property = new Complex2();
            // Set property of property
            complex1.Complex2Property.IntProperty = 7;
        }
    }
