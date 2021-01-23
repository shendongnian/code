    [Test]
    public void Y2kCheckerTest() {
      using(ShimsContext.Create()) {
        ShimDateTime.NowGet = () => new DateTime(2000, 1, 1);
        Y2KChecker.Check();
      }
    }
