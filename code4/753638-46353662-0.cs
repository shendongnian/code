    /* 
    Calculate the Text Width in pixels, then set the size for the GroupBox.
    */
    
    
    groupBoxA.SuspendLayout();
    
    
    SizeF stringSizeLabel;
    
    using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(new Bitmap(1, 1)))
    {
        Font stringFont = new Font("Microsoft Sans Serif", 8.25F);
        stringSizeLabel = graphics.MeasureString("SAMPLE TEXT", stringFont);
    }
    
    int iWidth = (int)(stringSizeLabel.Width * 1.35f); // Give a little extra width
    int iHeight = 78; // This is a sample value
    
    groupBoxA.Size = new System.Drawing.Size(iWidth, iHeight);
    groupBoxA.MinimumSize = new System.Drawing.Size(iWidth, iHeight);
    
    
    groupBoxA.ResumeLayout(false);
    groupBoxA.PerformLayout();
