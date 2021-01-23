    public class DomainIsolatedTests : IDisposable
    {
      private static int index = 0;
      private readonly AppDomain testDomain;
      
      public DomainIsolatedTests()
      {
        var name= string.Concat("TestDomain #", ++index);
        testDomain = AppDomain.CreateDomain(name, AppDomain.CurrentDomain.Evidence, AppDomain.CurrentDomain.SetupInformation);
        // Trace.WriteLine(string.Format("[{0}] Created.", testDomain.FriendlyName)); 
      }
      public void Dispose()
      {
        if (testDomain != null)
        {        
          // Trace.WriteLine(string.Format("[{0}] Unloading.", testDomain.FriendlyName));
          AppDomain.Unload(testDomain);        
        }
      }
      [Fact]
      public void Test1()
      {
        testDomain.DoCallBack(() => {
          var app = new System.Windows.Application();
          
          ...
          // assert
        });
      }
      [Fact]
      public void Test2()
      {
        testDomain.DoCallBack(() => { 
          var app = new System.Windows.Application();
          ...
          // assert
        });
      }
      [Fact]
      public void Test3()
      {
        testDomain.DoCallBack(() => {
          var app = new System.Windows.Application();
          
          ...
          // assert
        });
      }
      ...
    }
