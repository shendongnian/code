    public async Task CallingMethod()
    {
        //...
        SecondProject.API.Controllers.AccountController UserApiController = new SecondProject.API.Controllers.AccountController();
        await UserApiController.Register(UserApiModel);
        //...
    }
