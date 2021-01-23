     public class ChangePasswordViewModel(){
         public string OldPasswordHash {get; set;} //Remember never to store password in clear text
         public string NewPassword{ get; set; }
         public string RecoveryToken { get; set; }
     }
