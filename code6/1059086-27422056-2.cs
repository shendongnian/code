        [TestMethod()]
        public void GetLoggedInUserName_InvokedWithValidSetup_ReturnUserName()
        {
            // Arrange
            // Setup membership to return mocked user
            var membershipService = new Mock<IMembershipService>();
            var user = new Mock<MembershipUser>();
            user.Setup(x => x.UserName).Returns("Adam");
            user.Setup(x => x.ProviderUserKey).Returns("1df03f8c-74fa-423a-8be8-61350b4da59f");
            user.SetupGet(x => x.Email).Returns("adamw@test.com");
            membershipService.Setup(m => m.GetUserDetails(It.IsAny<string>())).Returns(user.Object);
            
            // Setup organization user service - You can ignore it or replace
            // based on what you are using.
            var organizationUserService = new Mock<IOrganizationUserService>();
            var organizationUser = new OrganizationUser
            {
                FirstName = "Adam",
                LastName = "Woodcock",
                MembershipId = new Guid("1df03f8c-74fa-423a-8be8-61350b4da59f")
            };
            organizationUserService.Setup(s => s.GetUserDetailsByMembershipId(It.IsAny<Guid>())).Returns(organizationUser);
            var mock = new Mock<ControllerContext>();
            mock.SetupGet(p => p.HttpContext.User.Identity.Name).Returns("Adam");
            var target = GetTargetController(membershipService, null, organizationUserService, null, null);
            target.ControllerContext = mock.Object;
            // Act
            var result = target.GetLoggedInUserName();
            // Assert
            Assert.AreEqual(organizationUser.FirstName + " " + organizationUser.LastName, result.Data);
        }
