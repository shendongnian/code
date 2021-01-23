    public partial class EmailServiceClient : System.ServiceModel.ClientBase<IEmailService>, IEmailService
    {
        
        . . .<SNIP> . . .
        
        public void SendEmail(EmailDTO email)
        {
            base.Channel.SendEmail(email);
        }
        
        public System.Threading.Tasks.Task SendEmailAsync(EmailDTO email)
        {
            return base.Channel.SendEmailAsync(email);
        }
    }
