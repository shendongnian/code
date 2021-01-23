    [TestMethod]
        public void PartialViewUnitTest()
        {
            // Arrange 
            InspectionController controller = new InspectionController();
            // Act 
            PartialViewResult result = controller.SomePartialView("stringHere") as PartialViewResult;
    
            // Assert 
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewName); 
        }
