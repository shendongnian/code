        [TestMethod()]
        public void InitTest()
        {
            bool eventOccurredAndSucceeded = false;
            Controller target = new Controller();
            target.FinishedCommand += delegate(bool success)
            {
                if (success)
                {
                    eventOccurredAndSucceeded = true;
                }
            };
            target.Init();
            Assert.AreEqual(true, eventOccurredAndSucceeded);
        }
