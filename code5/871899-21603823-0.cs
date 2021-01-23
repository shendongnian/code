    public class ObservableQueue : Queue
    {
        public event EventHandler<QueueChangedArgs> OnChanged;
        public override void Enqueue(object obj)
        {
            base.Enqueue(obj);
            if (OnChanged != null)
                OnChanged(this, new QueueChangedArgs(obj, QueueEventType.ItemEnqueued));
        }
    }
    public enum QueueEventType { ItemEnqueued, ItemDequeued }
    public class QueueChangedArgs : EventArgs
    {
        public object Item { get; private set; }
        public QueueEventType EventType { get; private set; }
        public QueueChangedArgs(object item, QueueEventType type)
        {
            Item = item;
            EventType = type;
        }
    }
