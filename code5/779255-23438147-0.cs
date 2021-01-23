    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
    
    namespace UnitTestLibrary1
    {
      [TestClass]
      public class UnitTest1
      {
        [TestMethod]
        [TestCategory("tests")]    <! -- Added Attribute -->
        public void TestMethod1()
        {
          string a = "a";
          string b = "b";
    
          Assert.AreEqual(a, b);
        }
      }
    }
