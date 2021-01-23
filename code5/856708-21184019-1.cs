    [Test]
    public void File_upload_test()
    {
        var contextmock = new Mock<HttpContextBase>();
        // Set up the mock here
        var mycontroller = new MyController(contextmock.Object);
        // test here
    }
