    string filePath)= @"C:\MyDir\filename.txt";
    public bool RemoveFile(string filePath)
    {
    try
    {
    if (File.Exists(filePath))
    {
    File.Delete(filePath);
    return true;
    }
    else
    return true;
    }
    catch (Exception ex)
    {
    return false;
    }
    }
