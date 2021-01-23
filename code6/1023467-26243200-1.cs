    public void B1_DragDrop(object sender, DragEventArgs e)
    {
        string B1fileName = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
        string B1result = Path.GetFileNameWithoutExtension(B1fileName);
        MessageBox.Show(B1result);
    }
