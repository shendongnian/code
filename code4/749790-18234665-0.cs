    string strpath = @"D:\Multilingual\Destinationfolder\folder1\folder2";
    string folderToFind = "Destinationfolder";
    var subfolders = new List<string>();
    if (strpath.Contains("Destinationfolder"))
    {
        subfolders.AddRange(Regex.Replace(strpath, @".*"+folderToFind, "")
             .Trim('\\')
             .Split('\\'));
    }
