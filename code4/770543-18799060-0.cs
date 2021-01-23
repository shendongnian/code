    void HandleExcelFile(string path)
    {
        try
        {
            // Function will perform actual work
            HandleExcelFileCore(path); 
        }
        catch (Exception) // Be more specific
        {
            Thread.Sleep(100); // Arbitrary
            
            try
            {
                HandleExcelFileCore(path);
            }
            catch (Exception)
            {
                string tempPath = Path.GetTempFileName();
                File.Copy(path, tempPath);
               
                try
                {
                    HandleExcelFileCore(tempPath);
                }
                finally
                {
                    File.Delete(tempPath);
                }
            }
        }
    }
