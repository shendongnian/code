    public interface IData { /** common elements **/ }
    public class psdata : IData
    {
            public int ID { get; set; }
            public string Address { get; set; }
            etc...
    }
    public class cpsdata : IData
    {
            public int ID { get; set; }
            public string Customer { get; set; }
            public string Address { get; set; }
            etc...
    }
