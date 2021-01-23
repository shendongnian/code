    pbs = new PictureBox[8];
    for (int i = 0; i < pbs.Length; i++)
    {
        pbs[i] = new PictureBox();
        pbs[i].MouseEnter += Picturebox_MouseEnter;
        pbs[i].MouseLeave += PictureBox_MouseLeave;
        pbs[i].Name = string.Concat("PB", i); //Added to identify each picturebox
        pbs[i].Size = new Size(100, 100);
        pbs[i].Margin = new Padding(0, 0, 0, 60);
        pbs[i].Dock = DockStyle.Top;
        pbs[i].SizeMode = PictureBoxSizeMode.StretchImage;
        Panel p = i < 4 ? panel1 : panel2;
        p.Controls.Add(pbs[i]);
        pbs[i].BringToFront();
    }
        
