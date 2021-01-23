        [TestMethod]
        public void CsvActionResultController_ExportToCSV_VerifyResponseContentTypeIsTextCsv()
        {
            // Arrange
            var httpResponseBaseMock = new Mock<HttpResponseBase>();
            httpResponseBaseMock.Setup(x => x.OutputStream).Returns(new Mock<Stream>().Object);
            var sut = new CsvActionResultTestClass(new DataTable());
            //Act
            sut.WriteFile(httpResponseBaseStub.Object);
            //Verify
            httpResponseBaseMock.VerifySet(response => response.ContentType = "text/csv");
        }
