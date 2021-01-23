    public interface IFoo
    {
        int Prop1 { get; set; }
        string Prop2 { get; set; }
        void WriteToTestStream();
    }
    public class Foo : IFoo
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
        // Surely this is internal implementation
        private Stream TestStream;
        public void WriteToTestStream() { }
    }
    public class Bar
    {
        private readonly IFoo _foo;
        public Bar(IFoo injectedFoo)
        {
            _foo = injectedFoo;
        }
        public void DoSomethingInOrder()
        {
            _foo.Prop1 = 1;
            _foo.Prop2 = "Baz";
            _foo.WriteToTestStream();
        }
        public void DoSomethingOutOfOrder()
        {
            _foo.WriteToTestStream();
            _foo.Prop2 = "Baz";
            _foo.Prop1 = 1;
        }
    }
