        private void tsi_MouseEnter(object sender, EventArgs e)
        {
            // Cast to allow reuse of method.
            ToolStripItem tsi = (ToolStripItem)sender;
    
            // Create semi-transparent picture.
            Bitmap bm = new Bitmap(tsi.Width, tsi.Height);
            for (int y = 0; y < tsi.Height; y++)
            {
                for (int x = 0; x < tsi.Width; x++)
                    bm.SetPixel(x, y, Color.FromArgb(150, Color.White));
            }
    
            // Set background.
            tsi.BackgroundImage = bm;
        }
