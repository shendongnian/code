    public class Greeter
    {
        private readonly IMessageService _messageService;
        private readonly ISubscriberRepository _subscriberRepository;
        public Greeter(IMessageService messageService, ISubscriberRepository subscriberRepository)
        {
            _messageService = messageService;
            _subscriberRepository = subscriberRepository;
        }
        public void SendGreetingToStackOverflow()
        {
            IEnumerable<Subscriber> stackOverflowers = _subscriberRepository.GetStackOverflowSubscribers();
            foreach (Subscriber overflower in stackOverflowers)
            {
                _messageService.SendSMS("Hello World!");
            }
        }
    }
