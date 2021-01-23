    protected override void OnMouseDown(MouseEventArgs e)
    {
        var parent = this.Parent as BarraSms;
        parent.mouseDown(e);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        var parent = this.Parent as BarraSms;
        parent.mouseMove(e);
    }
