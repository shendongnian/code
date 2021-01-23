    public interface IFoo
    {
        int Bar { get; set; }
    }
    public partial class Foo
    {
        public int Bar { get; set; }
    }
    public partial class Foo : IFoo
    {
    }
