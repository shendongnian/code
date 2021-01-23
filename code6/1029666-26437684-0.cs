    private void btnScan(object sender, EventArgs e)
    {
        string path = cmbDrive.Text;
        string extension = "*.mdf";
        string[] files = Directory.GetFiles(path, extension, SearchOption.AllDirectories);
        foreach(string s on files)
            lstvwdb2.Items.Add(s);
    }
