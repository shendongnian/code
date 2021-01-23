    public class Foo : ITest1
    {
        internal Poco Obj { get; set; }
        Poco ITest1.Obj { get { return Obj; } set { Obj = value; } }
    }
