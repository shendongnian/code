    Controller:
        [HttpPost]
        public JsonResult AddNewImage(string buildingID, string desc)
        {
            ReturnArgs r = new ReturnArgs();
            if (Request.Files.Count == 0)
            {
                r.Status = 102;
                r.Message = "Oops! That image did not seem to make it!";
                return Json(r);
            }
            if (!repo.BuildingExists(buildingID))
            {
                r.Status = 101;
                r.Message = "Oops! That building can't be found!";
                return Json(r);
            }
            SaveImages(buildingID, desc);
            r.Status = 200;
            r.Message = repo.GetBuildingByID(buildingID).images.Last().ImageID;
            return Json(r);
        }
        public class ReturnArgs
        {
            public int Status { get; set; }
            public string Message { get; set; }
        }
    Test:
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
