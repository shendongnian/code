    var repositoryMock = new Mock<ISurveyListRepository>();
    var surveys = new List<SurveyList>(); 
    string date = DateTime.Today.ToShortDateString();
    repositoryMock.Setup(r => r.GetSurveyList(date)).Returns(surveys);
    var surveyList = new SurveyListModel(repositoryMock.Object);
         
    var model = testClass.GetSurveyList(date);
    repositoryMock.VerifyAll();
    Assert.AreEqual(surveys, model);
