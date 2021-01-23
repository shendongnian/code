    private static UserCollection GetAllUsersWithNoCode()
    {
        UserQuery query = new UserQuery();
        query[AttributeNames.CommunityUser.AUTO_LOGIN_TOKEN] = new NullStringCriterion();
        return CommunitySystem.CurrentContext.DefaultSecurity.GetQueryResult(query);
    }
