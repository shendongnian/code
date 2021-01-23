    public ChildClass2 : BaseClass<IUserRepository2, IUser2>
    {
        public ChildClass()
        {
           IUserRepository2 userRepos = GetRepository();
           IUser2 user = GetInstance();
 
        }
    }
