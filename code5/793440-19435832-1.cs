    interface ITypeResolver
    {
      Type GetType(string typeName);
    }
    class SomeClass
    {
      private readonly ITypeResolver typeResolver = ...;
      public IAnInterface Instantiator()
      {
        var type = this.typeResolver.GetType(A_CONSTANT_STRING);
        return (IAnInterface)Activator.CreateInstance(type);
      }
    }
