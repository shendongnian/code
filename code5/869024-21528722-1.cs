    class CanSendMessagesToQueue
    {
        private Queue<Message> queue;
        public CanSendMessagesToQueue(Queue<Message> queue)
        {
            this.queue = queue;
        }
        public anotherMethod()
        {
            queue.Enqueue(new Message("Hello world!"));
        }
    }
