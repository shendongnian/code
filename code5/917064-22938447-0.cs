        [TestMethod]
        public void SelectProduct_Condition1_Test()
        {
            var prodName = string.Empty;
            var block = 1;
            var productAddressId = 0;
            var mockControllerContext = new Mock<ControllerContext>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["ReturnProductAddressID"]).Returns("123"); //somevalue
            mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
            var controller = new ProductController();
            controller.ControllerContext = mockControllerContext.Object;
            //Act         
            var actual = controller.SelectProduct(prodName, block, productAddressId);
        }
