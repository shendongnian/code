    private void CenterLabel()
    {
        int fontHeightPixels = (int)(greyBar.Height * .85);
        Font font = new System.Drawing.Font("Arial", fontHeightPixels, FontStyle.Regular, GraphicsUnit.Pixel);
        string text = "I am centered";
        //get the size of the text (you could do this before hand if needed)
        SizeF size = label18.CreateGraphics().MeasureString(text, font);
        label18.Font = font;
        label18.Text = text;
                        
        //center over picture box control and slightly above
        label18.Left = (pictureBox1.Width / 2) - (((int)size.Width) / 2) + pictureBox1.Left;
        label18.Top = (greyBar.Height / 2) - (((int)size.Height) / 2) + greyBar.Top;            
    }
