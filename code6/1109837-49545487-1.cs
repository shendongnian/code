    [TestFixture("Chrome", "IE", "Firefox")]
    class MyTests : TestBase
    {
         public MyTests(string _browser) : base(_browser) { }
         [Test]
         public void Test_001(){
              Driver.Goto("https://www.google.com");
         }
    }
