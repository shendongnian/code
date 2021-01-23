    public void AddNews(string path, string News_Title, string New_Desc)
    {
        string fileloc = Path.Combine(path, News_Title+".txt");
        if (!File.Exists(fileloc)) {
            File.WriteAllText(fileloc, New_Desc);           
        }
    }
