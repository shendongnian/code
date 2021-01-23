        public static IEnumerable<string[]> GetOrganizationType(User user)
        {
            return user.GetUserRoles()
                       .Select(ur => new[]
                                     {
                                         OrganizationType.Get(ur.organizationTypeId, "1").Name,
                                         ur.roleTypeId,
                                         ur.organizationId
                                     });
        }
