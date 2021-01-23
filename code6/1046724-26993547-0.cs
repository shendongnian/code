	public class LocalFolderWatcher : FileSystemWatcher, IWatcher
	{
	    //...
	    public event LocalFolderEventHandler CustomCreated;
	    
	    public LocalFolderWatcher()
	    {
	    	Created += OnCreated;
	    }
	
	    private new void OnCreated(object sender, FileSystemEventArgs e)
	    {
	        string path = System.IO.Path.GetDirectoryName(e.FullPath);
	        LocalFolderEventArgs args = new LocalFolderEventArgs(e.ChangeType, this._gatewayConfigurationName, path, this._folderConfigurationName, e.Name);
	
	        if (CustomCreated != null && base.EnableRaisingEvents && base.Path != null)
	            CustomCreated(this, args);
	    }
	}
