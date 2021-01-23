    // new mediaList 
    List<FileItem> mediaList = new List<FileItem>();
    ...
    private void lb1_DragDrop(object sender, DragEventArgs e)
    {
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        foreach (string f in files)
        {
            mediaList.Add(new FileItem(f));
        }
        // tell the LB to display whatever is in mediaList
        lb1.DataSource = mediaList;
    }
