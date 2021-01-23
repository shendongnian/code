    void Main()
    {
    	var watcher = new DirectoryWatcher("C:\\test\\", new TimeSpan(0, 0, 1));
    	watcher.Notification += (sender, args) => 
    		Console.WriteLine(string.Format("{0} was {1}", args.FileName, args.NotificationType));
    	
    	watcher.Start();
    	
    	Console.WriteLine("Press enter to stop.");
    	Console.ReadLine();
    	
    	watcher.Stop();
    }
    
    public class DirectoryWatcher
    {
    	public DirectoryWatcher(string directory, TimeSpan pollingFrequency)
    	{
    		this.Directory = directory;
    		this.PollingFrequency = pollingFrequency;
    	}
    
    	public string Directory { get; set; }
    	public TimeSpan PollingFrequency { get; set; }
    	
    	public System.Threading.Timer Timer { get; set; }
    	
    	private long ProcessCount;
    	
    	public void Start()
    	{
    		this.Timer = new Timer(Tick, null, 0, (int)PollingFrequency.TotalMilliseconds);
    	}
    	
    	public void Stop()
    	{
    		this.Timer.Dispose();
    	}
    	
    	DirectoryState previousState;
    	
    	private void Tick(object stateInfo)
    	{
    		if(Interlocked.Increment(ref ProcessCount) == 1)
    		{
    			try
    			{
    				if(previousState == null)
    				{
    					// First Run.
    					// Tell listeners about files that already exist in the directory.
    					previousState = new DirectoryState(this.Directory);
    					
    					foreach(var file in previousState.Files)
    					{
    						RaiseNotification(file.Key, DirectoryWatcherNotifiction.StartUp);
    					}
    				}
    				else
    				{
    					var currentState = new DirectoryState(this.Directory);
    					NotifyChanges(previousState, currentState);
    					previousState = currentState;
    				}
    			}
    			catch(Exception ex)
    			{
    				if(this.Error != null)
    				{
    					this.Error(this, new ErrorEventArgs(ex));
    				}
    			}
    		}
    		Interlocked.Decrement(ref ProcessCount);
    	}
    	
    	private void NotifyChanges(DirectoryState previous, DirectoryState current)
    	{
    		// Notify changes and deletions.
    		foreach(string fileName in previous.Files.Keys)
    		{
    			if(current.Files.ContainsKey(fileName))
    			{
    				if(!current.Files[fileName].Equals(previous.Files[fileName]))
    				{
    					RaiseNotification(fileName, DirectoryWatcherNotifiction.Changed);
    				}
    			}
    			else
    			{
    				RaiseNotification(fileName, DirectoryWatcherNotifiction.Deleted);
    			}
    		}
    	
    		// Notify new files.
    		foreach(string fileName in current.Files.Keys)
    		{
    			if(!previous.Files.ContainsKey(fileName))
    			{
    				RaiseNotification(fileName, DirectoryWatcherNotifiction.Created);
    			}
    		}
    	}
    		
    	private void RaiseNotification(string fileName, DirectoryWatcherNotifiction notificationType)
    	{
    		if(this.Notification != null)
    		{
    			this.Notification(this, new DirectoryWatcherEventArgs(fileName, notificationType));
    		}
    	}
    	
    	public EventHandler<DirectoryWatcherEventArgs> Notification { get; set; }
    	public EventHandler<ErrorEventArgs> Error { get; set; }
    }
    
    public class DirectoryWatcherEventArgs
    {
    	public DirectoryWatcherEventArgs(string fileName, DirectoryWatcherNotifiction notificationType)
    	{
    		this.FileName = fileName;
    		this.NotificationType = notificationType;
    	}
    
    	public string FileName { get; set; }
    	public DirectoryWatcherNotifiction NotificationType { get; set; }
    }
    
    public enum DirectoryWatcherNotifiction
    {
    	StartUp,
    	Deleted,
    	Changed,
    	Created
    }
    
    public class DirectoryState
    {
    	private DirectoryState()
    	{
    		this.Files = new Dictionary<string, DirectoryFileInfo>();
    	}
    	
    	public DirectoryState(string directory) 
    		: this()
    	{
    		this.DirectoryName = directory;
    	
    		foreach(var file in Directory.EnumerateFiles(directory))
    		{
    			this.Files.Add(file, new DirectoryFileInfo(file));
    		}
    	}
    
    	public string DirectoryName { get; set; }
    	public Dictionary<string, DirectoryFileInfo> Files { get; set; }
    }
    
    public class DirectoryFileInfo
    {
    	public DirectoryFileInfo(string fileName)
    	{	
    		var info = new FileInfo(fileName);
    		this.LastWriteTime = info.LastWriteTime;
    		this.FileSize = info.Length;
    	}
    
    	public DateTime LastWriteTime { get; set; }
    	public long FileSize { get; set; }
    	
    	public bool Equals(DirectoryFileInfo other)
    	{
    		return this.LastWriteTime == other.LastWriteTime && this.FileSize == other.FileSize;
    	}
    }
