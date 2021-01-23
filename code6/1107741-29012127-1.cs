    protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
    {
        base.OnElementChanged(e);
        if (Control == null)
            SetNativeControl(new UILabel());
        if (e.NewElement != null)
            Control.Text = e.NewElement.Text;
    }
