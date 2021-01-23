    class Foo {
        
        public static string Name { get; set; }
        public string Password { get; set; }
    
    }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Foo.Name);
            GetPost<Foo>();
            Console.WriteLine(Foo.Name);
        }
        
        public static void GetPost<T>() where T : new() {
            typeof(T).GetProperty("Name").SetValue(null, "djasldj");
        }
        
    }
