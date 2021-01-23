    void Main()
    {
    	string userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    	string subFolder = @"Local Settings\TEST";
    	string path = Path.Combine(userProfile, subFolder);
    	
    	DirectoryInfo di = new DirectoryInfo(path);
    	if (di.Exists)
    	{
    		Console.WriteLine("Deleting " + di);
    		di.Delete(true);//recursive
    	}
    	else
    	{
    		Console.WriteLine("Directory " + di + " was not found");
    	}
    }
