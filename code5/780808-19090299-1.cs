        static Func<string, UserModel> CreateFactory(IActiveDirectoryRepository repository)
        {
            return (userLogin) => 
            {
                var User = repository.FindById<ActiveDirectoryUser>(userLogin.ToUpper());
                return new UserModel()
                {
                    Login = userLogin,
                    DisplayName = User == null ? userLogin.ToUpper() : User.Name
                }   
            }
        }
