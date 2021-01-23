    private void buttonGrowShrink(object sender, EventArgs e)
    {
        var largeSize = new Size(320, 490);
        var smallSize = new Size(160, 245);
        if (this.Size.Width >= largeSize.Width || this.Size.Height >= largeSize.Height)
        {
            this.Size = smallSize;
        }
        else
        {
            this.Size = largeSize;
        }
    }
