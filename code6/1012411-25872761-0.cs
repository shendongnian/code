    void CopyFiles(string path, string savepath)
    {
        FileStream fsopen = new FileStream(path, FileMode.Open, FileAccess.Read);
        byte[] buf = new byte[1024];
    
        FileStream fsw = new FileStream(savepath, FileMode.Create, FileAccess.Write);
        int count = 0;
        while ((count=fsopen.Read(buf, 0, buf.Length))>0)
        {
            fsw.Write(buf, 0, count);
        }
    
        fsw.Flush();
        fsw.Close();
    }
