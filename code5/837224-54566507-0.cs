            private event EventHandler TestEventSingle;
        private event EventHandler TestEventMultiple;
        public OtherTests()
        {
            TestEventSingle += OtherTests_TestEvent;
            for (int i = 0; i < 100; i++)
            {
                TestEventMultiple += OtherTests_TestEventMultiple;
            }
        }
        private void OtherTests_TestEventMultiple(object sender, EventArgs e)
        {
            //Do something with the event...
        }
        private void OtherTests_TestEvent(object sender, EventArgs e)
        {
            //Do something with the event...
        }
        [Benchmark]
        public void InvokeEvent()
        {
            TestEventSingle.Invoke(this, null);
        }
        [Benchmark]
        public void InvokeEventMore()
        {
            TestEventMultiple.Invoke(this, null);
        }
        [Benchmark]
        public void CallMethod()
        {
            OtherTests_TestEvent(this, null);
        }
        [Benchmark]
        public void CallMethodMore()
        {
            for (int i = 0; i < 100; i++)
            {
                OtherTests_TestEventMultiple(this, null);
            }
        }
