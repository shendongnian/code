    public static void Main(string[] args)
    {
        using(var tempFolder = new TempFolder())
        {
            
            // Do my stuff using tempFolder.RootPath as base path to create new files
        }
        
        // temporal directory will be deleted when we reach here
        // even if an exception is thrown! :)
    }
