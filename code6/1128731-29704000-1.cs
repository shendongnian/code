    class Program
    {
    	static void Main(string[] args)
    	{
    		var details = GetFileDetails(@"c:\", "*.*", SearchOption.AllDirectories);
    		//var details = GetFileDetails(@"c:\", "*.png", SearchOption.AllDirectories);
    
    		var filesOfZeroSize = details.Where(detail => detail.Length <= 0).ToList();
    		var filesOfZeroSizeCount = filesOfZeroSize.Count;
    
    		if (filesOfZeroSizeCount > 0)
    		{
    			Console.WriteLine("There are {0} files with a length of 0.", filesOfZeroSizeCount);
    		}
    	}
    
    	public static List<FileDetail> GetFileDetails(string path, string searchPattern, SearchOption options)
    	{
    		var directory = new DirectoryInfo(path);
    
    		if (!directory.Exists)
    		{
    			throw new DirectoryNotFoundException("Path");
    		}
    
    		List<FileDetail> fileDetails = new List<FileDetail>();
    		FileInfo[] files = directory.GetFiles(searchPattern, options);
    		foreach (FileInfo fileInfo in files)
    		{
    			fileDetails.Add(new FileDetail(fileInfo.Name, fileInfo.Extension, fileInfo.Length));
    		}
    
    		return fileDetails;
    	}
    }
    
    class FileDetail
    {
    	public string FileName { get; set; }
    
    	public string Extension { get; set; }
    
    	public long Length { get; set; }
    
    	public FileDetail()
    		: this(null, null, -1)
    	{
    	}
    
    	public FileDetail(string fileName, string extension, long length)
    	{
    		this.FileName = fileName;
    		this.Extension = extension;
    		this.Length = length;
    	}
    }
