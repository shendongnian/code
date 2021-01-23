    interface IEmailGenerator{
        MailMessage BuildMailMessage(string message)
    }
    interface IEmailSender
    {
        void SendEmail(string message);
    }
    public class EmailGenerator : IEmailGenerator{
         public MailMessage BuildMailMessage(string message)
         {
              return new MailMessage();
         }
    }
    public class EmailSender : IEmailSender
    {
         private readonly IEmailGenerator _emailGenerator;
 
         public EmailSender (IEmailGenerator emailGenerator){
            _emailGenerator = emailGenerator;
         }
         public void SendEmail(string message)
         {
              var message = _emailGenerator.BuildMailMessage(message);
              //send email
         }
    }
  
