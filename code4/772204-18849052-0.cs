    public class Example
    {
        public string SomeProperty { get; set; }
        public static void DoSomething(Example instance)
        {
            var value = instance.SomeProperty;
        }
    }
