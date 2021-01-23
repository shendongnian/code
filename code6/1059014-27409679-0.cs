        [Test]
        public void BlockingTest()
        {
            AutoResetEvent ev = new AutoResetEvent(false);
            BlockingFunctionHelper(ev);    
            // specify time out in ms, thus here: wait 1 s
            Assert.IsTrue(ev.WaitOne(1000), "Execution not halted.");
            ev.Dispose();
        }
        private void BlockingFunctionHelper(AutoResetEvent ev)
        {
            ThreadPool.QueueUserWorkItem((e) =>
                {
                    BlockingFunction(); // this function halts execution indefinitely
                    ((AutoResetEvent) e).Set();
                }, ev);
        }
