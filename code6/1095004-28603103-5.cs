    public class CompositeMessageService : IMessageService
    {
		private readonly IMessageService messageServices;
		
        public CompositeMessageService(IMessageService[] messageServices)
        {
			if (messageServices == null)
				throw new ArgumentNullException("messageServices");
			this.messageServices = messageServices;
        }
		
		public void Send(IMessage message)
		{
			foreach (var messageService in this.messageServices)
			{
				messageService.Send(message);
			}
		}
    }
