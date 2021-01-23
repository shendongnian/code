    public void ResizeWidth(int newWidth)
    {
       this.Height = (int)((double)newWidth / (double)(this.Width / this.Height));
       this.Width = newWidth;
    }
    
    public void ResizeHeight(int newHeight)
    {
       this.Width = (int)((double)newHeight * (double)(this.Width / this.Height));
       this.Height = newHeight;
    }
