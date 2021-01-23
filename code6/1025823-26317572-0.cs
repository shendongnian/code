    private static readonly double AspectRatio = 
        (double)Screen.PrimaryScreen.Bounds.Width / Screen.PrimaryScreen.Bounds.Height;
        // Or any desired value
    protected override void OnResize(EventArgs e)
    {
        int minWidth = Math.Min(Width, (int)(Height * AspectRatio));
        if (WindowState == FormWindowState.Normal)
            Size = new Size(minWidth, (int)(minWidth / AspectRatio));
        base.OnResize(e);
    }
