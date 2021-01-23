    private void LoadImages(int startFrom, int to)
    {
        foreach(var control in flowLayoutPanel1.Controls)
        {
            if(control is LinkLabel)
            {
                // Detach handlers
                (control as LinkLabel).LinkClicked -= new LinkLabelLinkClickedEventHandler(LinkedLabelClicked);
            }
            // Dispose of controls we're about to clear out...
            control.Dispose();
        }
        flowLayoutPanel1.Controls.Clear();
        for (int file = startFrom; file < startFrom + to; file++)
        {
            LinkLabel l = new LinkLabel();
            l.Tag = FileManager.images[file];
            l.Text = Path.GetFileNameWithoutExtension(FileManager.images[file]);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            PictureBox picBox = new PictureBox();
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.ContextMenuStrip = contextMenuStrip1;
            picBox.Height = 125;
            picBox.Width = 125;
            picBox.LoadAsync(FileManager.images[file]);
            //Label lbl = new Label();
            // lbl.Text = Path.GetFileNameWithoutExtension(FileManager.images[file]);
            flowLayoutPanel1.Controls.Add(picBox);
            flowLayoutPanel1.Controls.Add(l);
            l.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkedLabelClicked);
            //flowLayoutPanel1.Controls.Add(lbl);
        }
    }
