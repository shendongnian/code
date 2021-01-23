    if (selected == 0)
    {      
        Panel p = new Panel();
        p.Height = 637;
        p.Width = 449;
        p.Location = new Point (269, 449);
        p.BorderStyle = BorderStyle.FixedSingle;
        p.Visible = true;
        p.BackColor = Color.White;
        p.AllowDrop = true;
        p.Dock = DockStyle.Top;
        ///p.Show();
        this.Controls.Add(p);
    
        MessageBox.Show("Now we should see the Panel");                
    }
