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
        
    And the handlers:
    
    
    private void Picturebox_MouseEnter(object sender, EventArgs e)
    {
        PictureBox pb = sender as PictureBox;
        if (pb != null)
        {
            if (pb.Name == "PB2")
            {
                //Do PB2 specific task
            }
            //Your code when mouse enters one of the pictureboxes
            //Use Name property to determine wich one, if needed
        }
    }
    
    private void PictureBox_MouseLeave(object sender, EventArgs e)
    {
        //Your code when mouse leaves one of the pictureboxes
        //Use Name property to determine wich one, if needed
    }
