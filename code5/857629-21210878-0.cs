    string date = DateTime.Today.ToString("MM/dd/yyyy");
    string filePath = ConfigurationSettings.AppSettings["FileName.txt"];
    using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    using(var reader = new StreamReader(fs))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] lineInfo = line.Split(' ');
            string NumbersTemp = lineInfo[1];
            string numbers = NumbersTemp.Replace(",", " ");
            // ...
        }
    }
