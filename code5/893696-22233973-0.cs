    List<FileInfo> fileList = new List<FileInfo>();
    foreach (var drive in System.IO.DriveInfo.GetDrives())
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(drive.Name);
            fileList.AddRange(dirInfo.GetFiles("*.pdf", SearchOption.AllDirectories));
        }
        catch (FieldAccessException ex)
        {
            //Log, handle Exception
        }
        catch (UnauthorizedAccessException ex)
        {
            //Log, handle Exception
        }
        catch (Exception ex)
        {
            //log , handle all other exceptions
        }
    }
