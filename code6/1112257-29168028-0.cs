    [TestMethod]
        public async Task TestNotifiableTimeOuts()
        {
            var msg = new NotifiableHttpMessage();
            TaskEx.Run(async () =>
            {
                await TaskEx.Delay(200);
                msg.setResponse(new Messages.HttpResponse());
            });
            var result= await msg.ContinueWhenResponseRecieved(50);
            Assert.IsFalse(result);
        }
