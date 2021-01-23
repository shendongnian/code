	public class LogfileBuilder
	{		
		private const string DEFAULT_PATH_1 = "EventLogging1.txt";
		private const string DEFAULT_PATH_2 = "EventLogging2.txt";
		
	    private readonly string _filePath1;
	    private readonly string _filePath2;
		private readonly long _delimiterSize;
	   
		public LogfileBuilder(long delimiterSize = 300)
		{
			_filePath1 = DEFAULT_PATH_1;
			_filePath2 = DEFAULT_PATH_2;
			_delimiterSize = delimiterSize;
		}
		
		public LogfileBuilder(string filePath1, string filePath2, long delimiterSize = 300)
		{
			_filePath1 = filePath1;
			_filePath2 = filePath2;
			_delimiterSize = delimiterSize;
		}
		
	    public void Log(string content)
	    {			
			//No file1
			if(File.Exists(_filePath1) == false)
			{
				//No file1, file2
				if(File.Exists(_filePath2) == false)
				{
					//Creates/overrides file1
					File.WriteAllText(_filePath1, content);
				}
				//file2, no file1
				else
				{
			        var fileInfo = new FileInfo(_filePath2);
					//file2 > delimiter
					if(fileInfo.Length > _delimiterSize)
					{
						File.Delete(_filePath2);
						//Creates/overrides file1
						File.WriteAllText(_filePath1, content);
					}
					//file2 < delimiter
					else
					{
						File.AppendAllText(_filePath2, content);
					}
				}				
			}
			//file1
			else
			{
				var fileInfo = new FileInfo(_filePath1);
				//file1 > delimiter
				if(fileInfo.Length > _delimiterSize)
				{
					File.Delete(_filePath1);
					//Creates/override filepath2
					File.WriteAllText(_filePath2, content);
				}
				//file1 < delimiter
				else
				{
					File.AppendAllText(_filePath1, content);	
				}
			}
	    }
	}
