    void SetWindowPosition()
    {
        this.Left = Settings.Default.WindowPositionLeft;
        this.Top = Settings.Default.WindowPositionTop;
    }
    void SaveWindowPosition()
    {
        Settings.Default.WindowPositionTop = this.Top;
        Settings.Default.WindowPositionLeft = this.Left;
        Settings.Default.Save();
    }
