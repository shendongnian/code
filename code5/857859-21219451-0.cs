    private void button1_Click(object sender, EventArgs e)
    {
        clearIECache();
    }
    void clearIECache()
    {
        ClearFolder(new DirectoryInfo(Environment.GetFolderPath
           (Environment.SpecialFolder.InternetCache)));
    }
    void ClearFolder(DirectoryInfo folder)
    {
        
            foreach (FileInfo file in folder.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception ex) // files used by another process exception
                {
                }
            }
            foreach (DirectoryInfo subfolder in folder.GetDirectories())
            {
                ClearFolder(subfolder); 
            }
        
    }
