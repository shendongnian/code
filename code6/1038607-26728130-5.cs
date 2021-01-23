    public class baseClass<T>
    {
      public baseClass<T> method1()
      {
        return this;
      }
    }
    public class inheritedClass : baseClass<inheritedClass>
    {
      public baseClass<inheritedClass> method2()
      {
        return this.method1();
      }
    }
