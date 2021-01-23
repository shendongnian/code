    class Program
    {
        static void Main(string[] args) {
            Test();
            Console.Read();
        }
        [Custom(Foo = "yup", Bar = 42)]
        static void Test() {
            // Get the MethodBase for this method
            var thismethod = MethodBase.GetCurrentMethod();
            // Get all of the attributes that derive from CustomAttribute
            var attrs = thismethod.GetCustomAttributes(typeof(CustomAttribute), true);
            // Assume that there is just one of these attributes
            var attr1 = (CustomAttribute)attrs.Single();
            // Print the two properties of the attribute
            Console.WriteLine("Foo = {0},  Bar = {1}", attr1.Foo, attr1.Bar);
        }
    }
    class CustomAttribute : Attribute
    {
        public string Foo { get; set; }
        public int Bar { get; set; }
    }
