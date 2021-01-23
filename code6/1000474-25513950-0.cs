    public new string Text
    {
        get { return this.PrePend + base.Text; }
        set { base.Text = value; }
    }
