    public interface ILoginManager 
    {
        void doLogin();
    }
    public class PasswordControl : ILoginManager
    {
       public PasswordControl()
       {
          // code here
       }
       public void doLogin()
       {
          // code here
          Debug.WriteLine("PasswordControl.doLogin()");
       }
    }
    public class PasswordControl2 : ILoginManager
    {
       public PasswordControl2()
       {
          // code here
       }
       public void doLogin()
       {
          // code here
          Debug.WriteLine("PasswordControl2.doLogin()");
       }
    }
