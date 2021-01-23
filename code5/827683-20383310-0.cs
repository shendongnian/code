    public class Class1
    {
        private object data;
        public class Class2
        {
            public void Foo(Class1 parent)
            {
                Console.WriteLine(parent.data);
            }
        }
    }
