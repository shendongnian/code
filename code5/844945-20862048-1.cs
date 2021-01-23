    namespace TestProject3
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                ProgressBar p = new ProgressBar();
                TestProject3.Class1.ProgBarDynamicDisplay pbdr = new     TestProject3.Class1.ProgBarDynamicDisplay(p, 100);
                pbdr.ShowVal(10);
            }
        }
    }
