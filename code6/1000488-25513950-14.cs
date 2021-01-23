    public new string Text // Bad pie!
    {
        get { return this.PrePend + base.Text; } // Bad pie!
        set { base.Text = value; }
    }
