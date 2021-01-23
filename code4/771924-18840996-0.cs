    public Form1()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.Manual;
        foreach (var scrn in Screen.AllScreens)
        {
            if (scrn.Bounds.Contains(this.Location))
            {
                this.Location = new Point(scrn.Bounds.Left, scrn.Bounds.Top);
                return;
            }
        }
    }
