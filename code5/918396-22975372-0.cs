    string projectPath = @"G:\filepath\example\example\";
    string[] folders = null;
    try
    {
        folders = Directory.GetDirectories(projectPath);
    }
    catch(Exception e)
    {
        Debug.WriteLine(e.Message);
    }
