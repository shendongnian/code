    public byte[] GetActiveWorkbook(Microsoft.Office.Interop.Excel.Application app)
    {
        string path = Path.GetTempFileName();
        try
        {
            app.ActiveWorkbook.SaveCopyAs(path);
            return File.ReadAllBytes(path);
        }
        finally
        {
            if(File.Exists(path))
                File.Delete(path);
        }
    }
