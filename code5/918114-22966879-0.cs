    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        this.Width = Screen.PrimaryScreen.WorkingArea.Width * 85 / 100;
        this.Height = Screen.PrimaryScreen.WorkingArea.Height * 85 / 100;
        this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width * 15 / 200, Screen.PrimaryScreen.WorkingArea.Height * 15 / 200);
    }
