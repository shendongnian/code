    public class QueueItem
    {
    }
    public class MyQueue : QueueHandler<QueueItem>
    {
        public override void HandleItems(QueueItem[] items)
        {
            // do your thing.
        }
    }
    
    public void Test()
    {
        MyQueue queue = new MyQueue();
        QueueItem item = new QueueItem();
        queue.Enqueue(item);
        QueueItem[] batch = new QueueItem[]
        {
            new QueueItem(),
            new QueueItem()
        };
        queue.Enqueue(batch);
        // even on dispose, all queued items will be processed in order to stop the QueueHandler.
        queue.Dispose();
    }
