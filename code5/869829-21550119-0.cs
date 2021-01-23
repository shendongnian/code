    public class ClassA<T>
    {}
    public class ClassB<T>:ClassA<T>
    {}
    ...
    public void MethodA<T1, T2>() where T1 : ClassA<T2>, new()
    {
      ClassA<T2> x=new ClassA<T2>();
    }
    ...
    public void MethodB<T1>() 
    {
      ClassA<T1> x = new ClassA<T1>();
    }
    
    MethodA<ClassB>();
