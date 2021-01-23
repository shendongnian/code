    string searchTerm = "Some terms";
        string[] MyFilesList = Directory.GetFiles(@"c:\txtDirPath\", "*.txt");
        List<string> FoundedSearch=new List<string>();
        foreach (string filename in MyFilesList)
        {
            string textFile = File.ReadAllText(filename);
            if (textFile.Contains(searchTerm))
            {
                FoundedSearch.Add(filename);
            }
        }
