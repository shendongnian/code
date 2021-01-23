    public class MyForm
    {
       ILoginManager _loginManager;
       public MyForm()
       {
          // let's assume read value is 2
          int choice = ReadChoiceFromConfigFile();
          if (choice == 1)
          {
             _loginManager = new PasswordControl();
          }
          else
          {
             _loginManager = new PasswordControl2();
          }
       }
    }
