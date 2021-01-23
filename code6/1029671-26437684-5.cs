    private void btnScan(object sender, EventArgs e)
    {
        string path = cmbDrive.Text;
        string extension = "*.mdf";
        foreach(string s in FileUts.GetFiles(path, extension))
            lstvwdb2.Items.Add(s);
    }
    public static class FileUts
    {
        // Code provided by Marc Gravell
        public static IEnumerable<string> GetFiles(string root, string searchPattern)
        {
           .....
        }
    }
