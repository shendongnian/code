    using System.Xml.Linq;
    using System.Xml.XPath;
    [TestClass]
    public class WebConfigTest
    {
        /// <summary>
        /// in Web.config, debug mode must be set to 'false'
        /// </summary>
        [TestMethod]
        public void TestDebugFalse()
        {
            var path        = @"Path to web.config";
            var config      = XDocument.Load(path);
            var compilation = config.XPathSelectElement("/configuration/system.web/compilation");
            var debug       = compilation.Attribute("debug").Value;
            Assert.AreEqual("false", debug);
        }
    }
