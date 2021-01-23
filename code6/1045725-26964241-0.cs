    string[] files = System.IO.Directory.GetFiles(strFolder);
    foreach (string strFile in files)
    {
      try { System.IO.File.Delete(strFile); }
      catch (Exception ex)
      {
        //Exception here
        AddToLog("JobCleaner.CleanFiles(): Error occurred when trying to delete file \"" + strFile + "\".\nError:\n" + ex.Message);
        return false;
      }
    }
