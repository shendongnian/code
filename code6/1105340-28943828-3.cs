    [TestMethod]
    public void GetArticleBody_Test_Valid()
    {
        // Create channel mock
        Mock<IIsesServiceChannel> channelMock = new Mock<IIsesServiceChannel>();    
        // setup the mock to expect the Reverse method to be called
        channelMock.Setup(c => c.GetArticleBody(1010000008)).Returns("110,956 bo/d, 1.42 Bcfg/d and 4,900 bc/d. ");
        // create string helper and invoke the Reverse method
        ArticleDataGridViewModel articleDataGridViewModel = new ArticleDataGridViewModel(channelMock.Object);
        string result = articleDataGridViewModel.MethodThatCallsService();
        //Assert.AreEqual("cba", result);
        //verify that the method was called on the mock
        channelMock.Verify(c => c.GetArticleBody(1010000008), Times.Once());
    }
