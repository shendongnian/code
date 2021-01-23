        [TestMethod]
        public void Index_WhenActionExecutes_EnsureReturnModelHasExpectedTenantName() 
        {
            const string expectedTensntName = "tenant name.";
            var fakeTenant = new Tenant { Name = expectedTensntName };
            var fakeUser = new User { CurrentTenant = (fakeTenant) };
            var userRepositoryStub = new Mock<IUserRepository>();
            userRepositoryStub.Setup(p => p.GetByEmail(It.IsAny<string>())).Returns(fakeUser);
            var identityRepositoryStub = new Mock<IIdentityRepository>();
            var sut = new AccountInfoController(userRepositoryStub.Object, identityRepositoryStub.Object);
            
            var requestContextStub = new Mock<RequestContext>();
            requestContextStub.Setup(x => x.HttpContext.Request.ApplicationPath).Returns(@"/");
            requestContextStub.Setup(x => x.HttpContext.Response.ApplyAppPathModifier(It.IsAny<string>()))
                .Returns((string s) => s);
            var fakeRoutes = new RouteCollection();
            fakeRoutes.MapRoute(name: "Default", url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            requestContextStub.SetupGet(x => x.RouteData).Returns(new RouteData());
            var result = sut.Index(requestContextStub.Object, fakeRoutes) as PartialViewResult;
            Assert.AreEqual(expectedTensntName, ((AccountInfoModel)result.Model).TenantName);
        }
