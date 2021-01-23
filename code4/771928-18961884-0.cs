	[ProtoContract]
	public class PayloadFile
	{
		[ProtoMember(1)]
	    public string FileName { get; set; }
		
		[ProtoMember(2)]
	    public string FileLocation { get; set; }
		
		[ProtoMember(3)]
	    public FileStream FileContent { get; set; }
	
		public PayloadFile()
		{
		}
	
	    public PayloadFile(string FileToLoad)
	    {
	        if (!File.Exists(FileToLoad))
	        {
	            throw new FileNotFoundException();
	        }
	        FileInfo PayloadInfo = new FileInfo(FileToLoad);
	        FileName = PayloadInfo.Name;
	        FileLocation = PayloadInfo.DirectoryName;
	        FileContent = File.OpenRead(FileToLoad);
	    }
		
	}
	
