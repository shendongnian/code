    void Main()
    {
    	// Use IoC container in real app:
    	var diskDrive = new DiskDrive(...);
    	var fileIndexer = new FileIndexer();
    	
    	var fileItems = diskDrive.GetImmediateFileItems(filePath);
    	fileIndexer.IndexFiles(fileItems);
    }
    
    // Define other methods and classes here
    public interface IDiskDrive
    {
      bool IsReady { get; }
    
      string Name { get; }
      string VolumeLabel { get; }
      string VolumeLabelName { get; }
    
      DiskDriveType Type { get; }
      FolderPath RootFolder { get; }
    
      DiskDriveUsage Usage { get; }
    
      IEnumerable<IFileItem> GetImmediateFileItems(FolderPath path);
    }
    
    public interface IFileIndexer
    {
    	void IndexFiles(IEnumerable<IFileItem> files);
    }
    
    public class FileIndexer : IFileIndexer
    {
    	public void IndexFiles(IEnumerable<IFileItem> files)
    	{
    		// do stuff
    	}
    }
