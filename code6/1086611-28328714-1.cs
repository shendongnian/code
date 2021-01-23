    namespace SpiController.Queue
    {
      public class FakeQueueService<T> : IQueueService
      {
        public FakeQueueService()
        {
            this.MessagesDeleted = new List<QueueMessage<T>>();
        }
        public IList<QueueMessage<T>> MessagesDeleted {
            get;
            private set;
        }
        public void Delete(QueueMessage<T> message)
        {
            this.MessagesDeleted.Add(message); 
        }
      }
    }
