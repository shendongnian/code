    public class Queue<T>       
        where T : IHasId, new()
    {
        public void Enqueue(Queueable<T> item)
        {
        }
    
        public Queueable<T> Dequeue()
        {
            return default(Queueable<T>);
        }
    }
