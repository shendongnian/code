    public class MyClass
    {
       public MyClass(object namespaceProvider)
          : this (namespaceProvider.GetType().Namespace)
       { }
    }
