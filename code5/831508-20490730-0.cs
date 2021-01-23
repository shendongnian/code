    ControlTemplate circleButtonTemplate = new ControlTemplate(typeof(Button));
    // Create the circle
    FrameworkElementFactory circle = new FrameworkElementFactory(typeof(Ellipse));
    circle.SetValue(Ellipse.FillProperty, Brushes.LightGreen);
    circle.SetValue(Ellipse.StrokeProperty, Brushes.Black);
    circle.SetValue(Ellipse.StrokeThicknessProperty, 1.0);
    // Create the ContentPresenter to show the Button.Content
    FrameworkElementFactory presenter = new FrameworkElementFactory(typeof(ContentPresenter));
    presenter.SetValue(ContentPresenter.ContentProperty, new TemplateBindingExtension(Button.ContentProperty));
    presenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
    presenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
    // Create the Grid to hold both of the elements
    FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));
    grid.AppendChild(circle);
    grid.AppendChild(presenter);
    // Set the Grid as the ControlTemplate.VisualTree
    circleButtonTemplate.VisualTree = grid;
    // Set the ControlTemplate as the Button.Template
    CircleButton.Template = circleButtonTemplate;
