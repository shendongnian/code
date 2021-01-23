    public Dictionary<string, ProfileGroupBase> GetGroupProfiles(MembershipUser user, string[] groups)
    {
         return groups.ToDictionary(group => group, GetUserProfile(user).GetProfileGroup);
    }
    public Dictionary<string, object> GetProfile(MembershipUser user, string[] properties)
    {
            return properties.ToDictionary(prop => prop, prop => UserProfile(user).GetPropertyValue(prop));
    }
