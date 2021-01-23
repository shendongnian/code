    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    namespace Hexify
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                string pattern = "[0-9A-F][0-9A-F]";
                string input = "50573953463435464438414B58413135";
    
                var matchCollection = Regex.Matches(input, pattern);
    
                List<string> strings = new List<string>();
    
                foreach (Match m in matchCollection)
                {
                    strings.Add(m.Value);
                }
    
                string result = String.Empty;
    
                if (strings.Count > 0)
                {
                    result = "0x" + String.Join(", 0x", strings);
                }
    
                Assert.AreEqual("0x50, 0x57, 0x39, 0x53, 0x46, 0x34, 0x35, 0x46, 0x44, 0x38, 0x41, 0x4B, 0x58, 0x41, 0x31, 0x35", result);
            }
        }
    }
