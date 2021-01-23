    internal static class QueueListener
    {
           private static readonly object QueueChangeLock = new object();
           private static readonly List<IQueuedJobExecutioner> jobsQueue = new List<IQueuedJobExecutioner>();
        
        // This is the singleton constructor that will be called
        static QueueListener()
        {
          // Here comes singleton private constructor, Instance property, all classic.
          // Important line in constructor is this:
          QueueManager.NewJobQueued += NewJobQueuedHandler;
        }
    	
    	// Rest of class code...
    }
