    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
    
    
    namespace CSharpClientToWrl
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                WrlTestClass2.WinRTClass _winRtTestClass = new WrlTestClass2.WinRTClass();
    
                int _answer = _winRtTestClass.Add(4, 6);
    
                Assert.AreEqual(_answer, 10);
            }
        }
    }
