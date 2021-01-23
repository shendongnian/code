    var visibilityBinding = new Binding("isInEditMode");
    visibilityBinding.Source = this;
    visibilityBinding.Converter = new BoolToVisibility();
    visibilityBinding.NotifyOnTargetUpdated = true;
    
    // here you setting the target property - VisibilityProperty
    slbi.SetBinding(SurfaceListBoxItem.VisibilityProperty, visibilityBinding);
