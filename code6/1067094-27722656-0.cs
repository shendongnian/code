    using NUnit.Framework;
    using Xania.AspNet.Simulator;
        [TestCase("ADMIN", true)]
        [TestCase("CUSTOMER", false)]
        public void AdminRoleAuthorizationTest(string roleName, bool isAuthorized)
        {
            // arrange
            var action = new AdminController().Action(c => c.Index()).Authenticate("user1", new[] {roleName});
            // assert
            Assert.AreEqual(isAuthorized, action.Authorize() == null);
        }
