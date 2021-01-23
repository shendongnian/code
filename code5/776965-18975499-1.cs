    public void WriteFile(string filename, bool readIntoMemory)
    {
        if (filename == null)
        {
            throw new ArgumentNullException("filename");
        }
        filename = this.GetNormalizedFilename(filename);
        FileStream f = null;
        try
        {
            f = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            if (this.UsingHttpWriter)
            {
                long length = f.Length;
                if (length > 0L)
                {
                    // this is false if you call the 
                    // HttpResponse.WriteFile(string fileName) 
                    if (readIntoMemory)
                    {
                        byte[] buffer = new byte[(int) length];
                        int count = f.Read(buffer, 0, (int) length);
                        this._httpWriter.WriteBytes(buffer, 0, count);
                    }
                    else
                    {
                        f.Close();
                        f = null;
                        this._httpWriter.WriteFile(filename, 0L, length);
                    }
                }
            }
            else
            {
                this.WriteStreamAsText(f, 0L, -1L);
            }
        }
        finally
        {
            if (f != null)
            {
                f.Close();
            }
        }
    }
    
     
