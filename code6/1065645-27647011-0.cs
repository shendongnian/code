    void lockPanel( bool lockIt)
    {
        if (lockIt)
        {    
            Bitmap bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Width);
            panel1.DrawToBitmap(bmp, panel1.ClientRectangle);
            panel1.BackgroundImage = bmp;
        }
        else
        {
            if (panel1.BackgroundImage != null)
                panel1.BackgroundImage.Dispose();
            panel1.BackgroundImage = null;
        }
        panelLocked = lockIt;
    }
