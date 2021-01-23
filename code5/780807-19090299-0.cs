        public sealed class UserFactory
        {
            private readonly IActiveDirecotryRepository repository;
            public UserFactory(IActiveDirectoryRepository repository)
            {
                this.repository = repository;
            }
            public UserModel CreateNewUser(string userLogin)
            {
                var User = repository.FindById<ActiveDirectoryUser>(userLogin.ToUpper());
                return new UserModel()
                {
                    Login = userLogin,
                    DisplayName = User == null ? userLogin.ToUpper() : User.Name
                } 
            }
        }
