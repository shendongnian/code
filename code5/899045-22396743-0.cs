    namespace SOWTests
    {
        using Microsoft.VisualStudio.TestTools.UnitTesting;
        [TestClass]
        public class PTests
        {
            [TestMethod]
            public void PTest()
            {
                string val = "1546";
                int id;
                int.TryParse(val, out id);
                Assert.AreEqual(1546, id);
            }
        }
    }
