    public bool isAllRequiredFilesExist()
    {
        string pathDirectory = Server.MapPath("~/UploadFiles/");
        string[] fileNameRequired = { "test1.txt", "test2.txt", "test3.txt" };
        //Check if all the required file exist in the folder
        foreach (string names in fileNameRequired)
        {
            //Loop through the folder
            //if there is a missing file then notified the user 
    
            foreach (string fileNameToCheck in Directory.EnumerateFiles(pathDirectory, names, SearchOption.AllDirectories))
            {
                if (!File.Exists(fileNameToCheck))
                {
                    lblMessage.Text = "Missing file: " + names;
                    return false;
                }    
            }
        }
    
        return true;
    }
