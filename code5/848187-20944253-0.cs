    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        Rectangle rect = GetTemplateChild("PART_TitleRectangle") as Rectangle;
        if (rect != null)
        {
            rect.MouseLeftButtonDown += (sender, e) => { DragMove(); };
        }
    }
