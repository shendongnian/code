    using (SFTDBEntities db = new SFTDBEntities())
    {
        db.CommandTimeout = int.MaxValue; //For test
   
        Guid Id_LogServerLogFile = Guid.Parse(lblId.Text.Trim());
        LogServerLogFile logServerLogFile = new LogServerLogFile();
        logServerLogFile = db.LogServerLogFiles.FirstOrDefault(x => x.Id == Id_LogServerLogFile);
        byte[] data = logServerLogFile.LogServerLogFilesData.TFFileData;
        long sz = logServerLogFile.TFFileSize;
        Response.ClearContent();
        Response.ContentType = logServerLogFile.TFFileMimeType;
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename = " + logServerLogFile.TFFileName));
        Response.AddHeader("Content-Length", sz.ToString("F0"));
        Response.Expires = 30;
        Response.Buffer = true;
        Response.BinaryWrite(data);
        Response.Flush();
        Response.End();
    }
