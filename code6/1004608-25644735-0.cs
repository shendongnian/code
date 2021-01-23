    private static int _folderNameCounter = 0;
    public static int GetFolderName()
    {
         lock(_folderNameCounter)
         {
             _folderNameCounter++;
             return _folderNameCounter()
         }
    }
    public static void Main()
    {
    }
