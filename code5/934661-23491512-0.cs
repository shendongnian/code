         public class RegisterClass{
             private IUser _user;              
             public RegisterClass(IUser user){
               _user = user;
             };
             public void Validate(){
             //you can validate the IUser.
             }
          }
          
        public class UserOne : IUser {
        }
 
        public class UserTwo : IUser {
        }
