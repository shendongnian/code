    string fileContent = Regex.Replace(File.ReadAllText("test.txt"), @"\r", ",");
    List<string> mapList = new List<string>();
    foreach (string map in Regex.Split(fileContent.Replace(@"\s+", ""), ","))
    {
        mapList.Add(map.Trim());
    }            
