    namespace ConsoleApplication1
    {
      using System;
      using System.Reflection;
      using System.Security;
      using System.Security.Policy;
      using System.Security.Principal;
    
      using HelloWorld2;
    
      class Program
      {
        static void Main(string[] args)
        {
          var fullPathToDll = "HelloWorld2.dll";
          var domainSetup = new AppDomainSetup
          {
            ApplicationBase = Environment.CurrentDirectory,
            PrivateBinPath = fullPathToDll
          };
    
          var ev1 = new Evidence();
    
          ev1.AddAssemblyEvidence(new ApplicationDirectory(typeof(Class1).Assembly.FullName));
    
          ev1.AddHostEvidence(new Zone(SecurityZone.MyComputer));
    
          var ad = AppDomain.CreateDomain("Class1", ev1, domainSetup, Assembly.GetExecutingAssembly().PermissionSet, null);
    
          var identity = new GenericIdentity("Class1");
          var principal = new GenericPrincipal(identity, null);
    
          ad.SetThreadPrincipal(principal);
    
          var remoteWorker = (Class1)ad.CreateInstanceFromAndUnwrap(
                fullPathToDll,
                typeof(Class1).FullName);
          remoteWorker.ExcuteMe();
        }
      }
    }
