    public class Foo
        {
            string name1;
            public Foo(string name1)
            {
                this.name1 = name1;
            }
            public virtual void something()
            {
                Console.WriteLine("Hello, " + name1);
            }
        }
        public class Bar : Foo
        {
            private string name2;
            public Bar(string name1, string name2)
                : base(name1)
            {
                this.name2 = name2;
                something();
            }
            public override void something()
            {
                base.something();
                Console.WriteLine("Good bye, " + name2);
            }
        }
