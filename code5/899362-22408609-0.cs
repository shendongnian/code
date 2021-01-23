    private int oldWidth;
    private int oldHeight;
    protected override void OnResizeBegin(EventArgs e)
    {
        oldWidth = Width;
        oldHeight = Height;
        base.OnResizeBegin(e);
    }
    protected override void OnResize(EventArgs e)
    {
        bool areBothChanged = Width != oldWidth && Height != oldHeight;
        ...
        base.OnResize(e);
    }
