    public class TurnOrderQueue<t> : IComparer<QueueItem<t>>
    {
        <skipped>
        public TurnOrderQueue()
        {
            turnOrderList = new SortedList<QueueItem<t>, t>(this);
        }
        public int Compare(QueueItem<t> item1, QueueItem<t> item2)
        {
            <skipped>
        }
     }
