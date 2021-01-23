    public class Queue<TItem, TQueueable>   
        where TItem : IHasId, new()
        where TQueueable: Queueable<TItem>
    {
        public void Enqueue(TQueueable<TItem> item)
        {
        }
    
        public TQueueable<TItem> Dequeue()
        {
            return default(TQueueable<TItem>);
        }
    }
