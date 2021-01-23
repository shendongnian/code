      public class ProxyDomain : MarshalByRefObject
      {
          public bool TestAssembly(string assemblyPath)
          {
             Assembly testDLL = Assembly.LoadFile(assemblyPath);
             //do whatever you need 
    
             return true;
          }
       }
     AppDomainSetup ads = new AppDomainSetup();
     ads.PrivateBinPath = Path.GetDirectoryName("C:\\some.dll");
     AppDomain ad2 = AppDomain.CreateDomain("AD2", null, ads);
     ProxyDomain proxy = (ProxyDomain)ad2.CreateInstanceAndUnwrap(typeof(ProxyDomain).Assembly.FullName, typeof(ProxyDomain).FullName);
     bool isTdll = proxy.TestAssembly("C:\\some.dll");
     AppDomain.Unload(ad2);
