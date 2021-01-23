        [Read my Blog Techhowdy][1]
    // For right 
                    pictureBox1.Top = ((Control)sender).Top;
                    pictureBox1.Height = ((Control)sender).Height;
        // For bottom
                     pictureBox1.Left = ((Control)sender).Left;
                     pictureBox1.Width= ((Control)sender).Width;
        // For top
                     pictureBox1.Top= ((Control)sender).Top;
                     pictureBox1.Width = ((Control)sender).Width;
        
        // Casting it to Control will solve your problem - use Left as it can be manupilated
    
    
      [1]: http://techhowdy.com
