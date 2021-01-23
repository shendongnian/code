    public static bool IsEnabled
    {
      get
      {
        return AuthenticationConfig.Mode == AuthenticationMode.Forms;
      }
    }
