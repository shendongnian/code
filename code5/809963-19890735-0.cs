    public void ShouldReturnFeedbacksForCorrectId()
    {
      var contextMock = new Mock<IWebAppDbContext>();
      // fill expected for example with 2 entitites with FeedbackForId == 1
      IQueryable<Feedback> expected = InitWithDataSomehow();
      contextMock.Setup(i => i.Feedbacks).Returns(expected);
      var repositoryUnderTest = new FeedbackRepository(contextMock);
      IQueryable<Feedback> actualResult = repositoryUnderTest.GetByFeedbackFor(1);
      Assert.AreEqual(expected, actualResult);
    }
