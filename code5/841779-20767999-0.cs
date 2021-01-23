    public interface IUser
    {
        string Id { get; }
        string UserName { get; set; }
    }
    public interface IUserStore<TUser> : IDisposable where TUser : IUser
    {
        Task CreateAsync(TUser user);
        Task DeleteAsync(TUser user);
        Task<TUser> FindByIdAsync(string userId);
        Task<TUser> FindByNameAsync(string userName);
        Task UpdateAsync(TUser user);
    }
