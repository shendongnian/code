    private void FillComboBox()
    {
        foreach(string dir in Directory.GetDirectories(@"C:\Temp\A"))
        {
            DirectoryInfo info = new DirectoryInfo(dir);
            //foldersCB is the Name of the ComboBox
            foldersCB.Items.Add(info);
        }
    }
