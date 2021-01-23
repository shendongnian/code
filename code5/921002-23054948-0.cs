    public class ExpensiveService : IExpensiveService
    {
        private object locker = new object();
    
        public void SendMessage(Message message)
        {
            lock (this.locker)
            {
                ...
            }
        }
    }
