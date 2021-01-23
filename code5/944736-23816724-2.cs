        [Test]
        public void Test_MyRepository_DeQueueTestProject()
        {
            // Add your unit test using MyRepository
            var r = new MyRepository();
            
            var commandMessage = r.DeQueueTestProject();
            Assert.AreEqual(commandMessage, new CommandMessage("What you want to compare"));
        }
