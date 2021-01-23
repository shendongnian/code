    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.All;
        else
        {
            String[] strGetFormats = e.Data.GetFormats();
            e.Effect = DragDropEffects.None;
        }
    }
