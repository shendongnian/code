    public class MyUserStore : IUserStore<MyUser>, IUserPasswordStore<MyUser>, IUserLockoutStore<MyUser, string>, IUserEmailStore<MyUser>
    {
        public Task<MyUser> FindByNameAsync(string userName)
        { 
            MyUser muser = dal.FindByUsername(userName);
        
            if (muser != null)
                return Task.FromResult<User>(muser);
                   
            return Task.FromResult<MyUser>(null);
        }
        //... all other methods
    }
