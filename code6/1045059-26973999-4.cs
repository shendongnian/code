    [TestClass]
    public class TestSelector
    {
        private IContainer container;
        [TestMethod]
        public void TestMethod()
        {
            var processor = container.Resolve<MessageReceiver>();
            MessageA ma = new MessageA();
            MessageB mb = new MessageB();
            processor.ReceiveMessage(ma);
            processor.ReceiveMessage(mb);
            Assert.AreEqual(ma.Handled, true);
            Assert.AreEqual(mb.Handled, true);
        }
    }
