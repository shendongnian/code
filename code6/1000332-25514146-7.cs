    //root visual of the ControlTemplate for DataGridCell is a Border
    var border = new FrameworkElementFactory(typeof(Border));
    border.SetBinding(Border.BorderBrushProperty, new Binding("BorderBrush") { 
            RelativeSource = RelativeSource.TemplatedParent
    });
    border.SetBinding(Border.BackgroundProperty, new Binding("Background") {RelativeSource = RelativeSource.TemplatedParent });
    border.SetBinding(Border.BorderThicknessProperty, new Binding("BorderThickness") {RelativeSource = RelativeSource.TemplatedParent });
    border.SetValue(SnapsToDevicePixelsProperty, true);
    //the only child visual of the border is the ContentPresenter
    var contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
    contentPresenter.SetBinding(SnapsToDevicePixelsProperty, new Binding("SnapsToDevicePixelsProperty") {RelativeSource=RelativeSource.TemplatedParent });
    contentPresenter.SetBinding(VerticalAlignmentProperty, new Binding("VerticalContentAlignment") { RelativeSource = RelativeSource.TemplatedParent });
    contentPresenter.SetBinding(HorizontalAlignmentProperty, new Binding("HorizontalContentAlignment") {RelativeSource = RelativeSource.TemplatedParent });
    //add the child visual to the root visual
    border.AppendChild(contentPresenter);
    //here is the instance of ControlTemplate for DataGridCell
    var template = new ControlTemplate(typeof(DataGridCell));
    template.VisualTree = border;
    //define the style
    var style = new Style(typeof(DataGridCell));
    style.Setters.Add(new Setter(TemplateProperty, template));
    style.Setters.Add(new Setter(VerticalContentAlignmentProperty, 
                                 VerticalAlignment.Center));
    style.Setters.Add(new Setter(HorizontalContentAlignmentProperty, 
                                 HorizontalAlignment.Center));
    yourDataGrid.CellStyle = style;
