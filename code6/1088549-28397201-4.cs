    UserService : IUserService
    {
        public void Add(User user)
        {
           //We couldn't even make it that far with an invalid User
           new UserValidator().ValidateAndThrow(user);
           userRepository.Save(user);
        }
    }
