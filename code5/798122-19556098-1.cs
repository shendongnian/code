    enum EmailAction { Update } // add any other possible actions
    public class Email
    {
        public string Email { get; private set; }
        public EmailAction  EmailAction { get; private set; }
        public string TemlateName { get; private set; }
        public DateTime DateTime { get; private set; }
        public Email(string email, EmailAction action, string templateName, DateTime dateTime)
        {
            this.Email = email;
            this.EmailAction = action;
            this.TemlateName = templateName;
            this.DateTime = dateTime;
        }
        public void Send()
        {
            //Build path from properties on this instance of Email
        }
    }
