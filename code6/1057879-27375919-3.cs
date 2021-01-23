        public static Dictionary<OrganizationType, UserRoles> GetOrganizationType(User user)
        {
            return user.GetUserRoles().ToDictionary(ur => OrganizationType.Get(ur.organizationTypeId, "1"),
                                                    ur => ur);
        }
