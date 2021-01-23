    Dictionary<string, Type> dict = new Dictionary<string, Type>();
    dict.Add("Foo", typeof(Foo));
    dict.Add("Bar", typeof(Bar));
    object obj = Activator.CreateInstance(dict[className]);
    ...
    public class Foo
    {
        public Foo()
        {
            Console.WriteLine("new foo");
        }
    }
    public class Bar
    {
        public Bar()
        {
            Console.WriteLine("new bar");
        }
    }
