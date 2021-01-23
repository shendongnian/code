    namespace NUnit.Tests
    {
      using System;
      using NUnit.Framework;
    
      private class AllTests
      {
        [Suite]
        public static IEnumerable Suite
        {
          get
          {
            ArrayList suite = new ArrayList();
            suite.Add(new OneTestCase());
            suite.Add(new AssemblyTests());
            suite.Add(new NoNamespaceTestFixture());
            return suite;
          }
        }
      }
    }
