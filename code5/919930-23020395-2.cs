    public class LoginViewModel
    {
       // other properties here
    
       public PasswordBox Password
       {
          get { return m_passwordBox; }
       }
    
       // Executed when the Login button is clicked.
       private void LoginExecute()
       {
          var password = Password.SecurePassword;
    
          // do more stuff...
       }
    }
