    interface IFoo
        {
            string Foo { get; }
        }
        abstract class Bar : IFoo
        {
            string IFoo.Foo { get;  set; }
        }
