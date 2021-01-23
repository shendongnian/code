    public IWindowHandler WindowHandler { get; set; }
    ...
    void myButton_Click(object sender, EventArgs e)
    {
        if (this.WindowHandler == null) return;
        this.WindowHandler.ButtonClicked(sender);
    }
