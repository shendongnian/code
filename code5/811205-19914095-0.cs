    PictureBox pb = new PictureBox();
    pb.SizeMode = PictureBoxSizeMode.AutoSize;
    pb.Anchor = AnchorStyles.None;
    pb.Image = bmp;
    pb.Location = new Point((this.ClientSize.Width / 2) - (pb.Width / 2),
                              (this.ClientSize.Height / 2) - (pb.Height / 2));
    this.Controls.Add(pb);
    this.AutoScrollMinSize = pb.Size;
