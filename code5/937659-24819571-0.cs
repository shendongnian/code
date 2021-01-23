    [TestFixture]
    public class BaseClass
    {
        public Mock<ControllerContext> controllerContext;
        public Mock<HttpContextBase> contextBase;
        public BaseClass()
        {
            controllerContext = new Mock<ControllerContext>();
            contextBase = new Mock<HttpContextBase>();
            controllerContext.Setup(x => x.HttpContext).Returns(contextBase.Object);
            controllerContext.Setup(x => x.HttpContext.User).Returns(principal);
            controllerContext.Setup(cc => cc.HttpContext.Session["UserId"]).Returns(1);
        }
    }
