    private void buttonGrowShrink(object sender, EventArgs e)
    {
        var largeSize = new Size(320, 490);
        var smallSize = new Size(160, 245);
        if (this.Size.Width >= largeSize.Width || this.Size.Height >= largeSize.Height)
        {
            this.Size = smallSize;
            button1.Text = "Grow Form";
        }
        else
        {
            this.Size = largeSize;
            button1.Text = "Shrink Form";
        }
    }
