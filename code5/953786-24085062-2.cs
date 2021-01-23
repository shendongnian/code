    [Test]
    public void TestingCallOrder() {
        int counter = 0;
        var mockDataAccessStuff = new Mock<IDataAccessStuff>();
        mockDataAccessStuff.Setup(x => x.AddCmdParameter(It.IsAny<string>())).Callback(() => {
            Assert.AreEqual(counter, 0);
            counter++;
        });
        mockDataAccessStuff.Setup(x => x.InitialiseDbCommand(It.IsAny<string>())).Callback(() => {
            Assert.AreEqual(counter, 1);
            counter++;
        });
        // more of the same
        var myClass = new ClassThatImTesting(mockDataAccessStuff.Object);
        myClass.DoWork();
        // make sure both methods are called at least once ...
        mockDataAccessStuff.Verify(x => x.AddCmdParameter(It.IsAny<string>()), Times.Once());
        mockDataAccessStuff.Verify(x => x.InitialiseDbCommand(It.IsAny<string>()), Times.Once());
    }
