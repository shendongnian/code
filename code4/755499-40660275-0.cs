    using System.Collections;
    namespace ReadOnly
    {
        class Program
        {
            static void Main(string[] args)
            {
                Foo foo1 = new Foo()
                {
                    Bar = new Bar()  // Compile error here - readonly property.
                    {
                        new Buzz() { Name = "First Buzz" }
                    }
                };
                Foo foo2 = new Foo()
                {
                    Bar = // No Compile error here.
                    {
                        new Buzz { Name = "Second Buzz" }
                    }
                };
            }
        }
        class Foo
        {
            public Bar Bar { get; }
        }
        class Bar : CollectionBase
        {
            public int Add(Buzz value)
            {
                return List.Add(value);
            }
            public Buzz this[int index]
            {
                get { return (Buzz)List[index]; }
                set { List[index] = value; }
            }
        }
        class Buzz
        {
            public string Name { get; set; }
        }
    }
