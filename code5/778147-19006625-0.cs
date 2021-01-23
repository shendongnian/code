            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(identity,null);
            fakeContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeContext.Object);        
          
             _requestController = new RequestController();
             
             //Set your controller ControllerContext with fake context
             _requestController.ControllerContext = controllerContext.Object; 
