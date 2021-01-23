    public IQueryable<UserProfile> GetAll(string _UserName)
    {
        IQueryable<UserProfile> query = this.UserProfiles.FirstOrDefault(x=>x.UserName==_UserName);
        return query;
    }
