    public class Greeter
    {
        private readonly IMessageService _messageService;
        public Greeter(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public void SendGreetingToStackOverflow()
        {
            _messageService.SendSMS("Hello World!");
        }
    }
