    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    public class LoginTests<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        
    [SetUp]
    public void Init()
    {
       Driver.Initialize<TWebDriver>();
    }
    [Test]
    public void Failed_login()
    {
        LoginPage.GoTo();
        LoginPage.LoginAs("user").WithPassword("pass").WithDatasource("db").Login();
        Assert.IsTrue(LoginFail.IsAt, "Login failure is incorrect");
    }
    [Test]
    public void Admin_User_Can_Login()
    {
        LoginPage.GoTo();
        LoginPage.LoginAs("user").WithPassword("pass").WithDatasource("db").Login();
        Assert.IsTrue(HomePage.IsAt, "Failed to login.");
    }
    [TearDown]
    public void Cleanup()
    {
      Driver.Close();
    }
    }
    }
