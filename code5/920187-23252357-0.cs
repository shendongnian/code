        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if ((entityEntry != null) && (entityEntry.State == EntityState.Added))
            {
                TUser user = entityEntry.Entity as TUser;
                if ((user != null) && this.Users.Any<TUser>(u => string.Equals(u.UserName, user.UserName)))
                {
                    return new DbEntityValidationResult(entityEntry, new List<DbValidationError>()) { ValidationErrors = { new DbValidationError("User", string.Format(CultureInfo.CurrentCulture, IdentityResources.DuplicateUserName, new object[] { user.UserName })) } };
                }
                IdentityRole role = entityEntry.Entity as IdentityRole;
                if ((role != null) && this.Roles.Any<IdentityRole>(r => string.Equals(r.Name, role.Name)))
                {
                    return new DbEntityValidationResult(entityEntry, new List<DbValidationError>()) { ValidationErrors = { new DbValidationError("Role", string.Format(CultureInfo.CurrentCulture, IdentityResources.RoleAlreadyExists, new object[] { role.Name })) } };
                }
            }
            return base.ValidateEntity(entityEntry, items);
        }
