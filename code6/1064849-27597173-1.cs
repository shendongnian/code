         PictureBox[] PicArray;
    PictureBox pb = new PictureBox();
            pb.BackgroundImage = Image.FromFile(@"C:\Esp_Calculator\ESP Planner\1206570458690641104johnny_automatic_bridge.svg.med.png");
            pb.Location = new Point(0, 0);
            pb.BackColor = Color.Transparent;
            pb.BackgroundImageLayout = ImageLayout.Zoom;
            pb.MouseDown += new MouseEventHandler(this.drawArea_MouseDown);
            pb.MouseMove += new MouseEventHandler(this.drawArea_MouseMove);
            pb.DoubleClick += pb_DoubleClick;
            drawArea.Controls.Add(pb);
            List<PictureBox> lblList = new List<PictureBox>();
            foreach (Control d in Controls)
                if (d is PictureBox)
                    lblList.Add((PictureBox)d);
            PicArray = lblList.ToArray();
          private void drawArea_MouseDown(object sender, MouseEventArgs e)
          {
           move = e.Location;
           }
         private void drawArea_MouseMove(object sender, MouseEventArgs e)
         {
        Control Pb = (Control)sender;
        if ((Control.ModifierKeys & Keys.Control) != 0)
        {
            if ((Control.MouseButtons & MouseButtons.Left) != 0)
            {
                Pb.Left += e.X - move.X;
                Pb.Top += e.Y - move.Y;
            }
        }
     }
     void pb_DoubleClick(object sender, System.EventArgs e)
        {
            Editor ed = new Editor();
            ed.Show();
        }
