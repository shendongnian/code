    private readonly IUserRepository _userRepository;
    public MyService(IUserRepository userRepository)   
    {
        this._userRepository = userRepository;
    }
    public bool CreateUser(DbUser user)
    {
        try
        {
                user.GenerateUserLight();
                user.GenerateUserProfileLight();
    
                var result = this._userRepository.InsertItem(user);
                this._userRepository.Save();
    
                return result;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
