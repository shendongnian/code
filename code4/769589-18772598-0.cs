    private void getFileList(object sender, EventArgs e)
    {
         try
         {
             DeleteOldBackupFiles();
         }
         catch (Exception ex)
         {
             //log exception or just put a breakpoint here.
         }
    }
