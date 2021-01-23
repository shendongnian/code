    [TestMethod()]
            public void SendTest()
            {
                Mock<ISmtpClient> smtpClient = new Mock<ISmtpClient>();
                SmtpProvider smtpProvider = new SmtpProvider(smtpClient.Object);
                string @from = "from@from.com";
                string to = "to@to.com";
                bool send = smtpProvider.Send(@from, to);
                Assert.IsTrue(send);
            }
