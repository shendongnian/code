    class Program
        {
            static void Main(string[] args)
            {
                ExampleClass ex1 = new ExampleClass();
                ExampleClass ex2 = new ExampleClass();
    
                ex1.normalfield = "new value for ex1";
                ex2.normalfield = "new value for ex2";
                ExampleClass.staticfield = "static value";
    
                Console.WriteLine(ex1.normalfield);
                Console.WriteLine(ex2.normalfield);
                Console.WriteLine(ExampleClass.staticfield);
    
            }
    
            class ExampleClass
            {
                public string normalfield = "";
                public static string staticfield = "";
            }
