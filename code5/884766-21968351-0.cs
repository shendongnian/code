    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
    
        anchor = Template.FindName("PART_ContentHost", this) as FrameworkElement;
    }
