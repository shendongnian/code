    string searchTerm = "Some terms";
        List<string> MyFilesList;//this is your list of files
        List<string> FoundedSearch=new List<string>();
        foreach (string filename in MyFilesList)
        {
            string textFile = File.ReadAllText(filename);
            if (textFile.Contains(searchTerm))
            {
                FoundedSearch.Add(filename);
            }
        }
