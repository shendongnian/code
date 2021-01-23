    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        this.displayRectangle = this.ClientRectangle;
        this.displayRectangle.Y += this.ItemSize.Height + 4;
        this.displayRectangle.Height -= this.ItemSize.Height + 4;
        foreach(TabPage page in this.TabPages)
        {
            page.SetBounds(
                this.DisplayRectangle.X, 
                this.DisplayRectangle.Y, 
                this.DisplayRectangle.Width, 
                this.DisplayRectangle.Height, 
                SpecifiedBounds.All
            );
        }
        this.Refresh();  // Can optimize this!
    }
    
