    public static UserModel Build(string userLogin, IKernel IoC)
    {
        var ActiveDirRepo = IoC.Get<IActiveDirectoryRepository>();
        var User = ActiveDirRepo.FindById<ActiveDirectoryUser>(userLogin.ToUpper());
        return new UserModel()
        {
            Login = userLogin,
            DisplayName = User == null ? userLogin.ToUpper() : User.Name
        };
    }
