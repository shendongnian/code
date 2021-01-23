    public class CustomQueue<T> : Queue<T>
    {
        public event EventHandler ItemDequeued;
        public event EventHandler ItemEnqueued;
        public new void Enqueue(T item)
        {
            base.Enqueue(item);
            if (ItemEnqueued != null) ItemEnqueued(this, EventArgs.Empty);
        }
        public new T Dequeue()
        {
            T a = base.Dequeue();
            if (ItemDequeued != null) ItemDequeued(this, EventArgs.Empty);
            return a;
        }
    }
    //Then you can handle the event ItemDequeued to know if its Count = 0
    yourQueue.ItemDequeued += (s, e) =>{
       if (yourQueue.Count == 0) MessageBox.Show("EMPTY queue!");
    };
