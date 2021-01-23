    private int oldWidth;
    private int oldHeight;
    private bool areBothChanged;
    protected override void OnResizeBegin(EventArgs e)
    {
        oldWidth = Width;
        oldHeight = Height;
        areBothChanged = false;
        base.OnResizeBegin(e);
    }
    protected override void OnResize(EventArgs e)
    {
        areBothChanged |= Width != oldWidth && Height != oldHeight;
        ...
        base.OnResize(e);
    }
