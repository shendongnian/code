	public class ParrelellTypeScheduler : TaskScheduler {
		// Indicates whether the current thread is processing work items.
	   [ThreadStatic]
	   private static bool _currentThreadIsProcessingItems;
	   // The list of tasks to be executed  
	   private readonly ConcurrentDictionary<object, LinkedList<Task>> _tasks = new ConcurrentDictionary<object, LinkedList<Task>>; // protected by lock(_tasks) 
	   // Indicates whether the scheduler is currently processing work items.  
	   private readonly Dictionary<object, bool> _typesRunning = new Dictionary<object,bool>();
	   // Queues a task to the scheduler.  
	   protected sealed override void QueueTask(Task task)
	   {
			LinkedList<Task> typesTasks = _tasks.GetOrAdd(task.AsyncState, new LinkedList<Task>());
			lock (typesTasks)
			{
				typesTasks.AddLast(task);
				if(!_typesRunning.ContainsKey(task.AsyncState) || _typesRunning[task.AsyncState] == false){
					_typesRunning[task.AsyncState] = true;
					NotifyThreadPoolOfPendingWork(task.AsyncState);
				}
			}
	   }
	   // Inform the ThreadPool that there's work to be executed for this scheduler.  
	   private void NotifyThreadPoolOfPendingWork(object type)
	   {
		   ThreadPool.UnsafeQueueUserWorkItem(_ =>
		   {
			   // Note that the current thread is now processing work items. 
			   // This is necessary to enable inlining of tasks into this thread.
			   _currentThreadIsProcessingItems = true;
			   try
			   {
				   LinkedList<Task> typedTasks;
				   if (_tasks.TryGetValue(type, out typedTasks)) {
				   
					   while (true) {
						   Task item;
						   lock (typedTasks)
						   {
							   // When there are no more items to be processed, 
							   // note that we're done processing, and get out. 
							   if (_tasks.Count == 0)
							   {
								   _typesRunning[type] = false;
								   break;
							   }
							   // Get the next item from the queue
							   item = typedTasks.First.Value;
							   typedTasks.RemoveFirst();
						   }
						   base.TryExecuteTask(item);
				
					   }
				   }
			   }
			   // We're done processing items on the current thread 
			   finally { _currentThreadIsProcessingItems = false; }
		   }, null);
	   }
	   // Attempts to execute the specified task on the current thread.  
	   protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
	   {
		   // If this thread isn't already processing a task, we don't support inlining 
		   if (!_currentThreadIsProcessingItems) return false;
		   // If the task was previously queued, remove it from the queue 
		   if (taskWasPreviouslyQueued) {
			  LinkedList<Task> typedTasks;
			  // Try to run the task.  
			  if (_tasks.TryGetValue(task.AsyncState, out typedTasks) && TryDequeue(typedTasks, task)) 
				return base.TryExecuteTask(task);
			  else 
				 return false; 
		   } else  
			  return base.TryExecuteTask(task);
	   }
	   // Attempt to remove a previously scheduled task from the scheduler.  
	   protected sealed override bool TryDequeue(LinkedList<Task> typedTasks, Task task)
	   {
		   lock (typedTasks) return typedTasks.Remove(task);
	   }
	   // Gets an enumerable of the tasks currently scheduled on this scheduler.  
	   protected sealed override IEnumerable<Task> GetScheduledTasks()
	   {
		   bool lockTaken = false;
		   try
		   {
			   Monitor.TryEnter(_tasks, ref lockTaken);
			   if (lockTaken) return _tasks.SelectMany(t => t.Value);
			   else throw new NotSupportedException();
		   }
		   finally
		   {
			   if (lockTaken) Monitor.Exit(_tasks);
		   }
	   }
	}
