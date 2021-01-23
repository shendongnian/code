    public class ModelFactory<T>
    {
        [Inject]
        public Lazy<IUserRepository> UserRepository { get; set; }
    }
