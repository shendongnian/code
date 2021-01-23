    public class BaanUserStore : IUserStore<IUser>, IUserPasswordStore<IUser>
    {
            public Task<IUser> FindByNameAsync(string userName)
            {
                //Wrong type!!
                return MyUser.Find(userName);            
            }
    }
