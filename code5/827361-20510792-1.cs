    [TestClass]
    public class UnitTestAsync
    {
        private Task<int> val = null;
        [TestInitialize]
        public void TestInitializeMethod()
        {
            val = TestInitializeMethodAsync();
        }
        private async Task<int> TestInitializeMethodAsync()
        {
            return await LongRunningMethod();
        }
        private async Task<int> LongRunningMethod()
        {
            await Task.Delay(20);
            return 10;
        }
        [TestMethod]
        public async Task TestMehod2()
        {
            Assert.AreEqual(10, await val);
        }
    }
