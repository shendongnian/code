    public interface IMyInterface
    {
        string Property1 { get; set; }
        string Property2 { get; set; }
    }
    public class MyClass : IMyInterface
    {
        public string Property1
        {
            get { return "MyClass"; }
            set {  }
        }
        public string Property2
        {
            get { return "MyClass"; }
            set { }
        }
    }
