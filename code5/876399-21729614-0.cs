    var mock = new Mock<ILogger>();
    string trace = null;
    mock.Setup(l => l.LogTrace(It.IsAny<string>(), It.IsAny<object[]>()))
            .Callback((s1, par) =>
                {
                    trace = string.Format(s1, par);
                });
    
    //rest of the test
    
    Assert.AreEqual(expected, trace);
