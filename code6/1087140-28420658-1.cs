        abstract class Foo
        {
            public int Id { get; set; }
            public abstract void Accept(Visitor visitor);
        }
        class Bar1 : Foo
        {
            public override void Accept(Visitor visitor)
            {
                visitor.Visit(this);
            }
        }
        class Bar2 : Foo
        {
            public override void Accept(Visitor visitor)
            {
                visitor.Visit(this);
            }
        }
        class Bar3 : Foo
        {
            public override void Accept(Visitor visitor)
            {
                visitor.Visit(this);
            }
        }
