    public class TaskManager<T> : Queue<T>
    {
    
        public delegate void taskDequeued();
    
        public event taskDequeued OnTaskDequeued;
    
        public override T Dequeue()
        {
            T ret = base.Dequeue();
            if (OnTaskDequeued != null) OnTaskDequeued();
            return ret;
        }
    
    }
