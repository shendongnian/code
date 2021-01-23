            var identity = new GenericIdentity("TestUsername");
            identity.AddClaim(new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "UserIdIWantReturned"));
            var fakePrincipal = A.Fake<IPrincipal>();
            A.CallTo(() => fakePrincipal.Identity).Returns(identity);
            var _controller = new MyController
            {
                ControllerContext = A.Fake<ControllerContext>()
            };
            
            A.CallTo(() => _controller.ControllerContext.HttpContext.User).Returns(fakePrincipal); 
