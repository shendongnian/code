    public class LoginAndRegisterViewModel
    {
      public LoginAndRegisterViewModel()
      {
        LoginViewModel = new LoginViewModel();
        RegisterViewModel  = new RegisterViewModel ();
      }
      public LoginViewModel LoginViewModel{ get; set; }
      public RegisterViewModel RegisterViewModel{ get; set; }
    }
