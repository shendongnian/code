    public override void OnApplyTemplate()
    {
        // Get access to parent control here, then
        parentControl.SizeChanged += Parent_SizeChanged;
    }
    public void Parent_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        Dimension = e.NewSize;
    }
