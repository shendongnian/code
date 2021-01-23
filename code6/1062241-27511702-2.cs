    public class Model
    {
        public int MyProperty { get; set; }
    }
    static void Main(string[] args)
    {
        // Prints "MyProperty"
        Console.WriteLine(GetPropertyName(model => model.MyProperty));
    }
