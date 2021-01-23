        public class GuidRole : IdentityRole<Guid, GuidUserRole> { 
            public GuidRole() {
                Id = Guid.NewGuid();
            }
            public GuidRole(string name) : this() { Name = name; }
        }
        public class GuidUserRole : IdentityUserRole<Guid> { }
        public class GuidUserClaim : IdentityUserClaim<Guid> { }
        public class GuidUserLogin : IdentityUserLogin<Guid> { }
        public class GuidUser : IdentityUser<Guid, GuidUserLogin, GuidUserRole, GuidUserClaim> {
            public GuidUser() {
                Id = Guid.NewGuid();
            }
            public GuidUser(string name) : this() { UserName = name; }
        }
        private class GuidUserContext : IdentityDbContext<GuidUser, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim> { }
        private class GuidUserStore : UserStore<GuidUser, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim> {
            public GuidUserStore(DbContext context)
                : base(context) {
            }
        }
        private class GuidRoleStore : RoleStore<GuidRole, Guid, GuidUserRole> {
            public GuidRoleStore(DbContext context)
                : base(context) {
            }
        }
        [TestMethod]
        public async Task CustomUserGuidKeyTest() {
            var manager = new UserManager<GuidUser, Guid>(new GuidUserStore(new GuidUserContext()));
            GuidUser[] users = {
                new GuidUser() { UserName = "test" },
                new GuidUser() { UserName = "test1" }, 
                new GuidUser() { UserName = "test2" },
                new GuidUser() { UserName = "test3" }
                };
            foreach (var user in users) {
                UnitTestHelper.IsSuccess(await manager.CreateAsync(user));
            }
            foreach (var user in users) {
                var u = await manager.FindByIdAsync(user.Id);
                Assert.IsNotNull(u);
                Assert.AreEqual(u.UserName, user.UserName);
            }
        }
