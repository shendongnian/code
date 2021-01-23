    private void application1ToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ofd.Filter = "EXE|*.exe";
        ofd.Title = "Add application";
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            ico = Icon.ExtractAssociatedIcon(ofd.FileName);
            button1.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
            button1.Image = ico.ToBitmap();
            button1.Enabled = true;
            // Added Line
            fileNames[0] = ofd.FileName;
        }
    }
Now in your on click button handler, instead of pulling the name from the OpenFileDialog you pull it from the array.
    private void button1_Click(object sender, System.EventArgs e)
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = fileNames[0];
        Process.Start(start);
    }
