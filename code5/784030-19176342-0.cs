    foreach (string dir in System.IO.Directory.GetDirectories(rootDirectory))
    {
        try
        {
            System.IO.Directory.Delete(dir);
        }
        catch
        {
            //There was a problem. Exit the loop?
        }
    }
