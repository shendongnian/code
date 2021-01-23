    public class Foo
    {
        string foo1 = "foo1", foo2 = "foo2", foo3 = "foo3";
        Bar bar1 = new Bar();
        public Bar Bar1
        {
            get { return bar1; }
            set { bar1 = value; }
        }
        public string Foo1
        {
            get { return foo1; }
            set { foo1 = value; }
        }
        public string Foo2
        {
            get { return foo2; }
            set { foo2 = value; }
        }
        public string Foo3
        {
            get { return foo3; }
            set { foo3 = value; }
        }
    }
