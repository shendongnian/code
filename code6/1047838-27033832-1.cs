    public abstract class Base
    {
        public abstract string BaseProp { get; }
    }
    public class MyBase : Base
    {
        public override string BaseProp { get { return "propA"; } }
        public string MyBaseProp { get; set; }
    }
    public class My : MyBase
    {
        public string MyProp { get; set; }
    }
