        public async Task<ActionResult> GetRolesForUser(string userId)
        {
            using (
                var userManager =
                    new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
            {
                var rolesForUser = await userManager.GetRolesAsync(userId);
                return this.View(rolesForUser);
            }
        }
