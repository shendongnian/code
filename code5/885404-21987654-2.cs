        for (int i = 1; i < 8; i++)
        {
           // Trackbars
           trackBarDmx.Add(new TrackBar());
           trackBarDmx[i].TickStyle   = trackBarDmx[0].TickStyle;
           trackBarDmx[i].Orientation = trackBarDmx[0].Orientation;
           trackBarDmx[i].Minimum     = trackBarDmx[0].Minimum;
           trackBarDmx[i].Maximum     = trackBarDmx[0].Maximum;
           trackBarDmx[i].Size        = new System.Drawing.Size(trackBarDmx[0].Size.Width, trackBarDmx[0].Size.Height);
           trackBarDmx[i].Location    = new System.Drawing.Point(trackBarDmx[i-1].Location.X + 60, trackBarDmx[0].Location.Y);
           this.Controls.Add(trackBarDmx[i]);
            
           // Notice no number in the handler name
           trackBarDmx[i].Scroll += trackBarDmx_Scroll;
         }
