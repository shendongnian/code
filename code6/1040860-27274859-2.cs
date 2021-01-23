	public class TaskRunnerPage : Page
	{
	    private TaskRunner<XElement> _taskrunner;
	    public void DoWork()
	    {
	        var work = Enumerable.Empty<WorkItem<XElement>>(); // TODO create your workItems
	        _taskrunner = new TaskRunner<XElement>(work);
	        _taskrunner.NeedsAttention.CollectionChanged += OnItemNeedsAttention;
	        Task.Run(() => _taskrunner.LongRunningTask()); // run this on a non-UI thread
	    }
	    private void OnItemNeedsAttention(object sender, NotifyCollectionChangedEventArgs e)
	    {
	        // e.NewItems contains items that need attention.
	        foreach (var item in e.NewItems)
	        {
	            var workItem = (WorkItem<XElement>) item;
	            // do something with workItem
	            PromptUser();
	        }
	    }
	    /// <summary>
	    /// TODO Use this callback from your UI
	    /// </summary>
	    private void OnUserAction()
	    {
	        // TODO create a new workItem with your changed parameters
	        var workItem = new WorkItem<XElement>();
	        _taskrunner.Queue(workItem);
	    }
	}
