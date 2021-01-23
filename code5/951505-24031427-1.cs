    public void ResizeWidth(int newWidth)
    {
       this.Height = (int)((double)newWidth / (double)((double)this.Width / (double)this.Height));
       this.Width = newWidth;
    }
    
    public void ResizeHeight(int newHeight)
    {
       this.Width = (int)((double)newHeight * (double)((double)this.Width / (double)this.Height));
       this.Height = newHeight;
    }
