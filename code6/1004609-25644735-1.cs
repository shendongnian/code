    private static int _folderNameCounter = 0;
    private static readonly object _padlock = new object();
    public static int GetFolderCounter()
    {
         lock(_padlock)
         {
             _folderNameCounter++;
             return _folderNameCounter;
         }
    }
    public static void Main()
    {
			for(int i = 0; i < 20; i++)
			{
				
				Task.Factory.StartNew(() => 
				 {
				 	var path = @"c:\temp\" + GetFolderCounter();
				 	Directory.CreateDirectory(path);
                    // add your own code for the thread here
				 });
			}
		
    }
