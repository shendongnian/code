    public class AccountController
    {
      private IUserFactory _userFactory;
    
      public AccountController(IUserFactory userFactory)
      {
        _userFactory = userFactory;
      }
      public ActionResult Register(RegisterModel model)
      {
        IUser user = _userFactory.CreateUser(model.Username, model.Password);
        ...
      }
    }
