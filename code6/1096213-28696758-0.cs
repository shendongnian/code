    public interface IMailSender {
        void Send(string message);
    }
    public class MailSender : IMailSender {
        public void Send(string message) {
        }
    }
    public class MailSenderProxy : IMailSender {
        private readonly Func<IMailSender> mailSenderFactory;
        public MailSenderProxy(Func<IMailSender> mailSenderFactory) {
            this.mailSenderFactory = mailSenderFactory;
        }
        public void Send(string message) {
            this.mailSenderFactory().Send(message);
        }
    }
