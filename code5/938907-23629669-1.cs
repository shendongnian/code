    public interface Base
    {
        string MyProperty { get; set; }
    }
    public interface Inherited : Base
    {
       
    }
    public class Implementor : Inherited
    {
        string Inherited.MyProperty { get; set; }
    }
