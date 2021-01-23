    DateTime expirydate = DateTime.Now.Subtract(TimeSpan.FromDays(14));
    
    DirectoryInfo exceptionsDirectory = new DirectoryInfo(pathToSave);
    
    foreach (FileInfo actualFile in exceptionsDirectory.GetFiles())
    {
        if (actualFile.LastWriteTime < expirydate)
        {
            try
            {
                File.Delete(actualFile.FullName);
            }
            catch (Exception ex)
            {
                // do ..
            }
        }
    }  
