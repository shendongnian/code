    [Test]
    public void ShouldAskQuestionOnConsole()
    {
        var message = "Hello World";
        var consoleMock = new Mock<IConsole>();
        consoleMock.Setup(c => c.Write(message));
        var question = new Question(consoleMock.Object, message);
        question.Ask();     
  
        consoleMock.VerifyAll();
    }
