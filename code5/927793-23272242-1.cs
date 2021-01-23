            [TestMethod]
            public void Index()
            {
                var mockHub = new Mock<IHomeHub>();
                // Arrange
                HomeController controller = new HomeController(mockHub.Object);
    
                // Act
                ViewResult result = controller.Index() as ViewResult;
    
                // Assert
                Assert.IsNotNull(result);
                mockHub.Verify(h=>h.Hello(), Times.Once);
            }
