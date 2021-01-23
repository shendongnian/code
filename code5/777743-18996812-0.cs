    // This can be handled any way you want, I prefer constants
    const string STABLE_FOLDER = @"C:\temp\stable\";
    const string UPDATE_FOLDER = @"C:\temp\updated\";
    
    // Get our files (recursive and any of them, based on the 2nd param of the Directory.GetFiles() method
    string[] originalFiles = Directory.GetFiles(STABLE_FOLDER,"*", SearchOption.AllDirectories);
    
    // Dealing with a string array, so let's use the actionable Array.ForEach() with a anonymous method
    Array.ForEach(originalFiles, (originalFileLocation) => 
    {		
    	// Get the FileInfo for both of our files
    	FileInfo originalFile = new FileInfo(originalFileLocation);
    	FileInfo destFile = new FileInfo(originalFileLocation.Replace(STABLE_FOLDER, UPDATE_FOLDER)); 
    									// ^^ We can fill the FileInfo() constructor with files that don't exist...
    	
    	// ... because we check it here
    	if (destFile.Exists)
    	{
    		// Logic for files that exist applied here; if the original is larger, replace the updated files...
    		if (originalFile.Length > destFile.Length)
    		{
    			originalFile.CopyTo(destFile.FullName, true);
    		}
    	}		
    	else // ... otherwise create any missing directories and copy the folder over
    	{
    		Directory.CreateDirectory(destFile.DirectoryName); // Does nothing on directories that already exist
    		originalFile.CopyTo(destFile.FullName,false); // Copy but don't over-write	
    	}
    			
    });
