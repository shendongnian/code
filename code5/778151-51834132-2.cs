            var userToTest = "User";
            string[] roles = null;
            var fakeIdentity = new GenericIdentity(userToTest);
            var principal = new GenericPrincipal(fakeIdentity, roles);
            var fakeHttpContext = new MockHttpContextBase { User = principal };
            var controllerContext = new ControllerContext
            {
                HttpContext = fakeHttpContext
            };
            // This is the controller that we wish to test:
			_requestController = new RequestController();
			// Now set the controller ControllerContext with fake context
			_requestController.ControllerContext = controllerContext; 			
