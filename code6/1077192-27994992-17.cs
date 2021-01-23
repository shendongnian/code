    private void lb1_DragDrop(object sender, DragEventArgs e)
    {
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        foreach (string f in files)
        {
            lb1.Items.Add(new FileItem(f));
            //mediaList.Add(m);
        }
    }
