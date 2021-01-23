    // arrange
    var serviceClient = MockRepository.GenerateMock<IMyServiceClient>();
    serviceClient.Stub(c => c.GetArticle(Arg<string>.Is.Anything)).Return("Article 1");
    var model = new ArticleViewModel(serviceClient);
    // act
    var result = model.LoadArticle("Thomas");
    // assert
    Assert.AreEqual("Article 1", result);
