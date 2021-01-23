            var userToTest = "User";
            string[] roles = null;
            var fakeHttpContext = new MockHttpContextBase();
            var fakeIdentity = new GenericIdentity(userToTest);
            var principal = new GenericPrincipal(fakeIdentity, roles);
            fakeHttpContext.User = principal;
            var controllerContext = new ControllerContext
            {
                HttpContext = fakeHttpContext
            };
			_requestController = new RequestController();
			//Set your controller ControllerContext with fake context
			_requestController.ControllerContext = controllerContext.Object; 			
