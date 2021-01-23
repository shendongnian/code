    [TestFixture]
    public partial class TestMethodInvocation
    {
      [Test]
      public void TestWithMoqVerify()
      {
        var callableMock = new Mock<Callable>();
        var test = new Test(callableMock);
        test.Start();
        callableMock.Verify(t => t.Called());
      }
    }
