    public class MailController : MailerBase
    {
        public EmailResult RegisterEmail()
        {
            From = System.Configuration.ConfigurationManager.AppSettings["RegistrationFrom"]; // or ContactFromAddress if you want
        }
    }
