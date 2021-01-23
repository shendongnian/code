    public interface IWebSecurity
    {
        bool CreateUserAndAccount(....);
    }
    
    public class MyWebSecurity: IWebSecurity
    {
        public bool CreateUserAndAccount(...)
        {
            WebSecurity.CreateUserAndAccount(...);
        }
    }
