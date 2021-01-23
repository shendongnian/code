    [TestMethod]
    public void IndexManualMoq()
    {
    .
    .
    .
        var controller = new SutController();
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new MockHttpContext
            {
                User = new GenericPrincipal(new GenericIdentity("JDoe"), null)
            }
        };
    .
    .
    .
    }
    private class MockHttpContext : HttpContextBase
    {
        public override IPrincipal User { get; set; }
    }
