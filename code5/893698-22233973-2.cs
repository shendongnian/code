    List<string> filePathList = new List<string>();
    foreach (DriveInfo drive in DriveInfo.GetDrives())
    {
        try
        {
            var filenames = Directory.EnumerateFiles(drive.Name, "*.pdf", SearchOption.AllDirectories);
            foreach (string fileName in filenames)
            {
                filePathList.Add(fileName);
            }
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
