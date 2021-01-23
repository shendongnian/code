        public static IEnumerable<string[]> GetOrganizationType(User user)
        {
            return from ur in user.GetUserRoles()
                   let ot = OrganizationType.Get(ur.organizationTypeId, "1")
                   select new[] {ot.Name, ur.roleTypeId, ur.organizationId};
        }
