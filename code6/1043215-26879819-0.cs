    public event EventHandler SelectionChanged;
    private int _selectionStart;
    private int _selectionLength;
    protected override void OnMouseDown(MouseEventArgs e)
    {
        _selectionStart = SelectionStart;
        _selectionLength = SelectionLength;
        base.OnMouseDown(e);
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (null != SelectionChanged && (_selectionStart != SelectionStart || _selectionLength != SelectionLength))
            SelectionChanged(this, EventArgs.Empty);
        base.OnMouseUp(e);
    }
}
