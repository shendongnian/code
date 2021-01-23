    class Foo
    {
        string name1;
        public Foo(string name1)
        {
            this.name1 = name1;
            somethingImpl();
        }
        virtual void something()
        {
           somethingImpl();
        }
        private void somethingImpl()
        {
           Console.WriteLine("Hello, " + name1);
        }
    }
