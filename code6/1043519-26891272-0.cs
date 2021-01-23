    public class EmailPersistence : IPersistence {
        private readonly MailAddress from;
        private readonly MailAddress to;
        public EmailPersistence(MailAddress from, MailAddress to) {
            this.from = from;
            this.to = to;
        }
        public bool Put(string data) {
            // How am I going to get the FROM and TO details?
            return EmailManager.Send(this.from, this.to, data.ToString());
        };
    }
