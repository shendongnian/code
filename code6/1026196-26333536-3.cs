    public class VerificationCode {
        public string Code { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
    
    // in your method
    VerificationCode newCode = new VerificationCode {
                                             Code="1559",
                                             ExpirationDate = System.DateTime.Now.AddMinutes(1)
                                         };
    Session["VerificationCode"] = newCode;
    
    
    // in the method where you check the expiration date and code...
    VerificationCode code = (VerificationCode)Session["VerificationCode"];
    // you can remove the verification code after pulling it out, as you only need
    //  it once, regardless of whether it is still good or expired.
    Session.Remove("VerificationCode");
    
    if (code.ExpirationDate < System.DateTime.Now){
       // the verification code expired...
       // can remove the verification code after successful login
       Session.Remove("VerificationCode");
    } else {
      // verification code is still good.
      // Log the user in?
      // can remove the verification code after successful login
      Session.Remove("VerificationCode");
    }
