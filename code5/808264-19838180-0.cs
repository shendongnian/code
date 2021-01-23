    public class ClassUnderTest
    {
      readonly ISomeDependency a;
      readonly IOtherDependency b;
    
      public ClassUnderTest() : this(new SomeDependency(), new OtherDependency())
      {
      }
      public ClassUnderTest(ISomeDependency a, IOtherDependency b)
      {
         this.a = a;
         this.b = b;
      }
    }
