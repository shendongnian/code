    ControlTemplate template = new ControlTemplate(typeof(ListBoxItem));
    FrameworkElementFactory elemFactory = new FrameworkElementFactory(typeof(Border));
    elemFactory.Name = "Border";
    elemFactory.SetValue(Border.CornerRadiusProperty, new CornerRadius(5));
    elemFactory.SetValue(Border.PaddingProperty, new Thickness(1));
    elemFactory.SetValue(Border.SnapsToDevicePixelsProperty, true);
    template.VisualTree = elemFactory;
    //same can be used as 
    LookUpEdit.PopupContentTemplate = template;
