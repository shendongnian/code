    private void openInputImagesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ...
        pb.MouseDoubleClick += new MouseEventHandler((s,x) => showLargeImage(sender,e,imageIndex));
    }
