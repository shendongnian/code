    //System Under Test - i.e to test User
    public class SutController : Controller
    {
        public string Get() {
            return User.Identity.Name;
        }
    }
    public class TestableControllerContext : ControllerContext {
        public TestableHttpContext TestableHttpContext { get; set; }
    }
    public class TestableHttpContext : HttpContextBase {
        public override IPrincipal User { get; set; }
    }
    [TestMethod]
    public void IndexNoneMoq()
    {
        var identity = new GenericIdentity("tugberk");
        var controller = new SutController();
        var controllerContext = new TestableControllerContext();
        var principal = new GenericPrincipal(identity, null);
        var testableHttpContext = new TestableHttpContext
        {
            User = principal
        };
        controllerContext.HttpContext = testableHttpContext;
        controller.ControllerContext = controllerContext;
        Assert.AreEqual(controller.Get(), identity.Name);
    }
