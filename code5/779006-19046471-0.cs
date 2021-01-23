        public class ReturnArgs
        {
            public int Status { get; set; }
            public string Message { get; set; }
        }
        [TestMethod]
        public void AddNewImage_Returns_Error_On_No_File()
        {
            // Arrange
            ExtendedBuilding bld = repo.GetBuildings()[0];
            string ID = bld.Id;
            var fakeContext = new Mock<HttpContextBase>();
            var fakeRequest = new Mock<HttpRequestBase>();
            fakeContext.Setup(cont => cont.Request).Returns(fakeRequest.Object);
            fakeRequest.Setup(req => req.Files.Count).Returns(0);
            BuildingController noFileController = new BuildingController(repo);
            noFileController.ControllerContext = new ControllerContext(fakeContext.Object, new System.Web.Routing.RouteData(), noFileController);
            // Act
            var result = noFileController.AddNewImage(ID, "empty");
            ReturnArgs data = (ReturnArgs)(result as JsonResult).Data;
            // Assert
            Assert.IsTrue(data.Status == 102);
        }
