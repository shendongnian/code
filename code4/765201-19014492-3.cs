    public class UserService:IService {
        public UserService(IUserRepository, IMailer, ILogger){
          // for example you can follow the next use case in your BL
          // try to login, if failed reteat after 3 time you block the accunt and send a mail
       
        }
       public bool login(string username, string password){
       }
    
    }
