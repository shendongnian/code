    var panel = new FlowLayoutPanel();
    panel.SuspendLayout(); // don't calculate the layout before all picture boxes are added
    panel.Size = new Size(491, 152);
    panel.Location = new Point(12, 12);
    panel.BorderStyle = BorderStyle.Fixed3D;
    panel.FlowDirection = FlowDirection.LeftToRight;
    panel.AutoScroll = true; // automatically add scrollbars if needed
    panel.WrapContents = false; // all picture boxes in a single row
    this.Controls.Add(panel);
    for (int i = 0; i < PresCount; ++i)
    {
        var pictureBox = new PictureBox();
        // the location is calculated by the FlowLayoutPanel
        pictureBox.Size = new Size(75, 75);
        pictureBox.BorderStyle = BorderStyle.FixedSingle;
        pictureBox.ImageLocation = "imgPath";
        panel.Controls.Add(pictureBox);
    }
    panel.ResumeLayout(); 
