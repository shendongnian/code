    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_WithDependecySetupCorrectly_ReturnTestString()
        {
            var mockHelper = new Mock<IConstantHelper>();
            const string testDataString = "TestString";
            mockHelper.Setup(z => z.ConstantForLog).Returns(testDataString);
            //Creating Instance for the HomeController
            var controller = new HomeController(mockHelper.Object);
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(testDataString, result.ViewName);
        }
    }
