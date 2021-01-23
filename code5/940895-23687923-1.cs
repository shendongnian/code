    var repositoryMock = new Mock<ISurveyListRepository>();
    string date = DateTime.Today.ToShortDateString();
    repositoryMock.Setup(r => r.GetSurveyList(date)).Returns(CreateTestSurveys());
    var model = new SurveyListModel(repositoryMock.Object);
         
    var surveys = model.GetSurveyList(date);
    repositoryMock.VerifyAll();
    CollectionAssert.AreEqual(CreateTestSurveys(), surveys);
