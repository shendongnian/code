    public class AuthenticationModel : BaseModel, IModel
    {
        public void PerformMainFunction()
        {
            // authenticate
        }
    }
    public class PasswordResetModel : BaseModel, IModel
    {
        public void PerformMainFunction()
        {
            // reset password
        }
    }
    public class BaseModel
    {
        public int UserTypeId { get; set; }
    }
    public interface IModel
    {
        void PerformMainFunction();
        int UserTypeId { get; set; }
    }
    public class EmailService : IEmailService
    {
        private readonly IModel _emailModel;
        ...
        public EmailService(IModel emailModel, EmailType emailType, IEmailRepository emailRepository)
        {
            _emailModel = emailModel;
           ...
