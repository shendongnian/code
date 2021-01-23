    public void WhenDoingActionXthenTidyUpIsCalled(){
      var filesUtil = new Mock<IFilesUtility>();
      var sut = new YourClassUnderTest( filesUtil.object );
      sut.DoSomethingThatTriggersTidyUp();
      filesUtil.verify( f => f.TidyUp(), Times.Once());
    }
