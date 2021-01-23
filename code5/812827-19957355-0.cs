    Mock<IDbContext> mockContext = new Mock<IDbContext>();
    question TestQuestion = new question { 
        Id = 1,
        ToAsk = "Did this test work?"
    };
    IDbSet<question> questions = new InMemoryDbSet<question>(true){ TestQuestion };
    mockContext.Setup(c => c.EntitySet<question>()).Returns(questions);
    QuestionsController controller = new QuestionsController( mockContext.Object );
    List<DHT.Entity.Models.question> questions = controller.Get();
    Assert.AreEqual(questions.Count, 1);
