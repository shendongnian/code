    public class ClassABase
    { }
    
    public abstract class ClassA<T> : CkassABase
    {}
    
    public void MethodA<T, K>() where T:ClassABase, new()
    {
      T<string> x=new T<string>();
    }
