    public interface IData { /** common elements **/ void Foo(); }
    public class psdata : IData
    {
            public int ID { get; set; }
            public string Address { get; set; }
            etc...
            public void Foo() {
                 // psdata specific
            }
    }
    public class cpsdata : IData
    {
            public int ID { get; set; }
            public string Customer { get; set; }
            public string Address { get; set; }
            etc...
            public void Foo() {
                 // cpsdata specific
            }
    }
