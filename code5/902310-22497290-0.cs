     public static Mock<ControllerContext> MockSession()
            {
                var controllerContext = new Mock<ControllerContext>();
                controllerContext.Setup(X => X.HttpContext.Session["UserName"]).Returns("Avinash");
                return controllerContext;
            }
