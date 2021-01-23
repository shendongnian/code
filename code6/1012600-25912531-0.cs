    using Project1;
    private class UnitTestClassQuiz
    {
    [TestMethod]
    public void ShouldReturnDivisibles()
    {
      //Arrange
      Quiz q = new Quiz();
    
      //Act
      var actual = q.ReturnDivisibles(60) 
