    public class UserRoleService
    {
       public UserRoleService(ModelFactory<UserRole> factory){}
    }
    public class ModelFactory<T>
    {
        [Inject]
        public IUserRepository UserRepository { get; set; }
    }
