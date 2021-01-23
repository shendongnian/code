    public ViewA _viewA { get; set; }
    public ViewB(ViewA viewA)
    {
       _viewA = viewA;
       ...
    }
    
    protected override void OnClosed(EventArgs e)
    {
       _viewA.Show();
       base.OnClosed(e);
    }
