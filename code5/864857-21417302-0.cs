    Response.Clear();
    Stream iStream = null;
    const int bufferSize = 64 * 1024;
    byte[] buffer = new Byte[bufferSize];
    int length;
    long dataToRead;
    try
    {
        iStream = new FileStream(strLocalFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        dataToRead = iStream.Length;
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + strLocalFilePath);
        while (dataToRead > 0)
        {
            if (Response.IsClientConnected)
            {
                length = iStream.Read(buffer, 0, bufferSize);
                Response.OutputStream.Write(buffer, 0, length);
                Response.Flush();
                buffer = new byte[bufferSize];
                dataToRead = dataToRead - length;
            }
            else
            {
                //prevent infinate loop on disconnect
                dataToRead = -1;
            }
        }
    }
    catch (Exception ex)
    {
        //Your exception handling here
    }
    finally
    {
        if (iStream != null)
        {
            iStream.Close();
        }
        Response.Close();
    }
