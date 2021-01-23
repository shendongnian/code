    public bool ckIsFileOpnen(string sFileFullPath)
            {
                try
                {
                    using (Stream stream = new FileStream(sFileFullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                    }
                    return true; //file is available for write
                }
                catch { }
    
                return false;
            }
