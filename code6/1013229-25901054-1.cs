    extern alias AssemblyA;
    extern alias AssemblyB;
    
    public class Test
    {
       public void TestMethod()
       {
          var aFooBar = new AssemblyA.Foo.Bar();
          var bFooBar = new AssemblyB.Foo.Bar(); 
       }
    }
