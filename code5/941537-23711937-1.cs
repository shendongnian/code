    for (int i = 0; i < 16; i++)
    {
        PictureBox p = new PictureBox();
        p.Location = new Point(10, (i + 1) * 20);
        p.Size = new Size(10, 10);
        p.BorderStyle = BorderStyle.FixedSingle;
        groupBox1.Controls.Add(p);
    }
