    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    
    namespace Model_Library
    {
        [TestClass]
        public class test
        {
            [TestMethod]
            public void test2()
            {
                string url = @"https://dc2-vault.myvzw.com/dv/api/user/c107a6db69104a10bc247a28fb81131e/";
                string data = @"search?query=" + Uri.EscapeDataString(@"contentType:audio/* AND (genre like 'RoyalJatt.Com )')") + @"&sort=name+asc&start=1&count=2147483647";
                string enc = Uri.EscapeUriString(url) + data;
    
                Console.Write(enc);
            }
        }
    }
