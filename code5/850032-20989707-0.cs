    public class ConcurrentQueueMailbox : Mailbox
    {
        // ...
        private BackgroundWorker _worker = new BackgroundWorker();
        public ConcurrentQueueMailbox()
        {
            _worker.DoDowr+=(sender, e) =>
            {
                // your code here...
            };
        }
        public override void Post(Envelope envelope)
        {
            if (envelope.Payload is SystemMessage)
            {
                systemMessages.Enqueue(envelope);
            }
            else
            {
                userMessages.Enqueue(envelope);
            }
            // Run only if not running already...
            if (!_worker.IsBusy)
            {
                _worker.RunWorkerAsync();
            }
        }
    }
