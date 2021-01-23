    class Program
    {
        static void Main(string[] args)
        {
            var types = new[] {typeof(A), typeof(B), typeof(C)};
            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<NameAttribute>();
                if (attribute != null)
                    Console.WriteLine(attribute.Name);
            }
            Console.ReadLine();
        }
        public sealed class NameAttribute : Attribute
        {
            public string Name { get; private set; }
            public NameAttribute(string name)
            {
                Name = name;
            }
        }
        [Name("A Name")]
        public class A
        {
        }
        [Name("B Name")]
        public class B
        {
        }
        [Name("C Name")]
        public class C
        {
        }
    }
