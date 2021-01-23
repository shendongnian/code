	public class TaskRunner<T>
	{
	    private readonly Queue<WorkItem<T>> _queue;
	    
	    public ObservableCollection<WorkItem<T>> NeedsAttention { get; private set; }
	    public bool WorkRemaining
	    {
	        get { return NeedsAttention.Count > 0 && _queue.Count > 0; }
	    }
	    public TaskRunner(IEnumerable<WorkItem<T>> items)
	    {
	        _queue = new Queue<WorkItem<T>>(items);
	        NeedsAttention = new ObservableCollection<WorkItem<T>>();
	    }
	    public event EventHandler WorkCompleted;
	    public void LongRunningTask()
	    {
	        while (WorkRemaining)
	        {
	            if (_queue.Any())
	            {
	                var workItem = _queue.Dequeue();
	                if (workItem.Validate())
	                {
	                    workItem.Action(workItem.Data);
	                }
	                else
	                {
	                    NeedsAttention.Add(workItem);
	                }
	            }
	            else
	            {
	                Thread.Sleep(500); // check if the queue has items every 500ms
	            }
	        }
	        var completedEvent = WorkCompleted;
	        if (completedEvent != null)
	        {
	            completedEvent(this, EventArgs.Empty);
	        }
	    }
	    public void Queue(WorkItem<T> item)
	    {
            // TODO remove the item from the NeedsAttention collection
	        _queue.Enqueue(item);
	    }
	}
