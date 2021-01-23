        [TestInitialize]
        public void TestSetup()
        {
            t.Tick += new CountDownTimer.TickHandler(MockTickEvent);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            t.Tick -= MockTickEvent;
        }
        void MockTickEvent(CountDownTimer m, EventArgs e, int seconds)
        {
            ///you may need to add further test code here to fully cover your code
            return;
        }
