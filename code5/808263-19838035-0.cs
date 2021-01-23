    public class ClassUnderTest
    {
      readonly ISomeDependency a;
      readonly IOtherDependency b;
     
      public ISomeDependency A{Get{return a;}}
      public ISomeDependency B{Get{return b;}}
    
      // constructor called by code
      public ClassUnderTest()
      {
         this.a = new SomeDependency();
         this.b = new OtherDependency();
      }
    }
    
    [TestMethod]
    public void DefaultCTOR_CreatesDependencies()
    {
        var sut = new ClassUnderTest();
        Assert.IsNotNull(sut.A,"sut didn't create SomeDependency A");
        Assert.IsNotNull(sut.B,"sut didn't create OtherDependency B");
    }
