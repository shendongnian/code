    public ChildClass : BaseClass<IUserRepository, IUser>
    {
        public ChildClass()
        {
           IUserRepository userRepos = GetRepository();
           IUser user = GetInstance();
 
        }
    }
