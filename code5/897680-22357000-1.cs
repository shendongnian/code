    public void LoadDirectories()
    {
        var drives = DriveInfo.GetDrives();
        foreach (var drive in drives)
        {
            this.treeView.Items.Add(this.GetItem(drive));
        }
