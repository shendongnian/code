    public class VerificationCode{
        public string Code {get;set;}
        public DateTime ExpirationDate {get;set;}
    }
    
    // in your method
    VerificationCode newCode = new VerificationCode {
                                             Code="1559",
                                             ExpirationDate = System.DateTime.Now.AddMinutes(1)
                                         };
    Session("VerificationCode") = newCode;
    
    
    // in the method where you check the expiration date and code...
    VerificationCode code = (VerificationCode)Session("VerificationCode");
    
    if (code.ExpirationDate < System.DateTime.Now){
       // the verification code expired...
    } else {
      // verification code is still good.
      // Log the user in?
    }
