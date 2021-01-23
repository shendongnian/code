    [Test]
    public static void test_do_something() {
        var applicationRootService = new Mock<IApplicationRootService>();
        applicationRootService.Setup(service => service.GetApplicationRoot()).Returns(new Uri("MyRoot", UriKind.Relative);
        var myClass = new DoWork(applicationRootService.Object);
        //continue testing!
    }
