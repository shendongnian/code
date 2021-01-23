    protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            if (context.Request.IsAuthenticated)
            {
                string[] roles = LookupRolesForUser(context.User.Identity.Name);
                var newUser = new GenericPrincipal(context.User.Identity, roles);
                context.User = Thread.CurrentPrincipal = newUser;
            }
        }
        #region helper
        private string[] LookupRolesForUser(string userName)
        {
            string[] roles = new string[1];
            CosmosMusic.Models.korovin_idzEntities db = new CosmosMusic.Models.korovin_idzEntities();
            var roleId = db.Users.Where(x => x.username == userName).FirstOrDefault().id_role;
            roles[0] = db.Role.Where(y => y.id_role == roleId).FirstOrDefault().name;
            return roles;
        }
        #endregion
