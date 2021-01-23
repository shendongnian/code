    private void LoadPic()
    {
        string path = @"Path here";
        
        PictureBox pic;
        FlowLayoutPanel panel;
        int x = 0;
        int y = 0;
        foreach ( string item in Directory.GetFiles ( path ) )
        {
            pic = new PictureBox ();
            panel = new FlowLayoutPanel ();
            panel.Location = new Point ( x, y );
            pic.Size = new System.Drawing.Size (100, 100 );
            pic.ImageLocation =  item;
            panel.Controls.Add ( pic );
            pic.Click +=pic_Click;
            panel1.Controls.Add ( panel );
            y = y + 100;
            
        }
    }
