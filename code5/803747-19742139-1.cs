        [TestMethod]
        public void CsvActionResultController_ExportToCSV_VerifyResponsePropertiesAreSetWithExpectedValues()
        {
            var sut = new HomeController();
            var httpResponseBaseMock = new Mock<HttpResponseBase>();
            //This would return a fake Output stream to you SUT 
            httpResponseBaseMock.Setup(x => x.OutputStream).Returns(new Mock<Stream>().Object);
            var httpContextBaseStub = new Mock<HttpContextBase>();
            httpContextBaseStub.SetupGet(x => x.Response).Returns(httpResponseBaseMock.Object);
            var controllerContextStub = new Mock<ControllerContext>();
            controllerContextStub.SetupGet(x => x.HttpContext).Returns(httpContextBaseStub.Object);
            sut.ControllerContext = controllerContextStub.Object;
            var result = sut.Index();
            httpResponseBaseMock.VerifySet(x => x.ContentType = "text/csv");
            httpResponseBaseMock.Verify(x => x.AddHeader("Content-Disposition", "attachment; filename=SomeFile.csv"));
            //Any other verifications...
        }
