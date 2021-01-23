    public interface IClass
    {
    }
    [MyMetadata(MyClassType.TypeOne)]
    public class MyClassA : IClass
    {
        public MyClassType Type
        {
            get { return MyClassType.TypeOne; }
        }
    }
    [MyMetadata(MyClassType.TypeTwo)]
    public class MyClassB : IClass
    {
        public MyClassType Type
        {
            get { return MyClassType.TypeTwo; }
        }
    }
