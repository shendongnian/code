    class Program
    {
        static void Main(string[] args)
        {
            var myClass = new MyClass()
            {
                Number = 1,
                String = "test"
            };
    
            var properties = myClass.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    
            foreach (var property in properties)
            {
                var columnName = property.Name;
                var value = myClass.GetType().GetProperty(columnName).GetValue(myClass, null);
                Console.WriteLine(string.Format("{0} - {1}", columnName, value));
            }
            Console.ReadKey();
        }
    }
    
    public class MyClass
    {
        public int Number { get; set; }
        public string String { get; set; }
    }
