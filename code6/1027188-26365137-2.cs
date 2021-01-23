    void DirSearch(string sDir)
    {
        foreach (var d in System.IO.Directory.GetDirectories(sDir))
        {
            ListBox1.Items.Add(d.TrimEnd('\\').Split('\\').Last());
            DirSearch(d);
        }
    }
