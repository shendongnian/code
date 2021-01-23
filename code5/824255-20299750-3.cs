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
            suite.Add(typeof(OneTestCase));
            suite.Add(typeof(AssemblyTests));
            suite.Add(typeof(NoNamespaceTestFixture));
            return suite;
          }
        }
      }
    }
