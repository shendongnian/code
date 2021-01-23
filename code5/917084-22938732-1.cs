    public class LocateTargetFilesCommand 
    {
    	private string[] _targetExtensions = new[]
    		{
    			"xlsx", "doc"
    		};
    
    	public LocateTargetFilesCommand()
    	{
    		FoundTargets = new ConcurrentQueue<string>();
    		DirsToSearch = new List<string>();
    	}
    
    	public ConcurrentQueue<string> FoundTargets { get; private set; }
    	public List<string> DirsToSearch { get; private set; }
    
    	public void Execute()
    	{
    		DriveInfo[] driveInfos = DriveInfo.GetDrives();
    
    		Console.WriteLine("Start searching");
    		foreach (var driveInfo in driveInfos)
    		{
    
    			if (!driveInfo.IsReady)
    				continue;
    
    			Console.WriteLine("Locating directories for drive: " + driveInfo.RootDirectory);
    			GetAllDirs(driveInfo.RootDirectory.ToString());
    			Console.WriteLine("Found {0} folders", DirsToSearch.Count);
    
    			foreach (var ext in _targetExtensions)
    			{
    				Console.WriteLine("Searching for .*" + ext);
    
    				int currentNotificationProgress = 0;
    				for (int i = 0; i < DirsToSearch.Count; i++)
    				{
    					int progressPercentage = (i * 100) / DirsToSearch.Count;
    					if (progressPercentage != 0)
    					{
    						if (progressPercentage % 10 == 0 && currentNotificationProgress != progressPercentage)
    						{
    							Console.WriteLine("Completed {0}%", progressPercentage);
    							currentNotificationProgress = progressPercentage;
    						}
    					}
    
    					var dir = DirsToSearch[i];
    					try
    					{
    						string[] files = Directory.GetFiles(dir, "*." + ext, SearchOption.TopDirectoryOnly);
    						foreach (var file in files)
    						{
    							FoundTargets.Enqueue(file);
    						}
    					}
    					catch (UnauthorizedAccessException ex)
    					{
    						Console.WriteLine("Skipping directory: {0}", dir);
    						DirsToSearch.Remove(dir);
    					}
    				}
    
    				Console.WriteLine("So far located {0} targets", FoundTargets.Count);
    			}
    
    			DirsToSearch.Clear();
    		}
    		
    		Console.WriteLine("Stop searching");
    	}
    
    	public void GetAllDirs(string root)
    	{
    		try
    		{
    			string[] dirs = Directory.GetDirectories(root);
    			DirsToSearch.AddRange(dirs);
    			foreach (var dir in dirs)
    			{
    				GetAllDirs(dir);
    			}
    		}
    		catch (UnauthorizedAccessException)
    		{
    			//swallow
    		}
    	}
    }
