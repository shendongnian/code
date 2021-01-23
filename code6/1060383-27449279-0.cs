    class Program
    {
        static void Main(string[] args)
        {
            var something = new ClassWithAttributes();
            var attributes = typeof(ClassWithAttributes).GetCustomAttributesData();
            var attribute = (SomeAttribute) Attribute.GetCustomAttribute(typeof(ClassWithAttributes), typeof (SomeAttribute));
            Console.WriteLine(attribute.Name);
            Console.ReadKey(false);
        }
    }
    [Some("larry")]
    class ClassWithAttributes
    {
    }
    public class SomeAttribute : System.Attribute
    {
        public string Name { get; set; }
        public SomeAttribute(string name)
        {
            this.Name = name;
        }
    }
