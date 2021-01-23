    private void button1_Click(object sender, EventArgs e)
    {
        openFileDialog1.InitialDirectory = getPath();
        openFileDialog1.ShowDialog();
    }
    private string getPath()
    {
        DirectoryInfo di = new DirectoryInfo(@"C:\blabla\bla\");
        foreach (var d in di.EnumerateDirectories())
        {
            foreach(var fi in d.EnumerateFileSystemInfos())
            {
                if (fi.Name == "blabla.png")
                {
                    return fi.FullName.Replace(fi.Name,"");
                }
            }
        }
        return di.FullName ;
    }
