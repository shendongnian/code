    // create the label with some context
    var lbl = new Label() { DataContext = new ImageData(imagePath) };
    // control template i want to put on the label
    ControlTemplate labelLayout = new ControlTemplate();
    // will be my main container that will be by template later on
    FrameworkElementFactory grdContainer = new FrameworkElementFactory(typeof(Grid));
    grdContainer.Name = "myContainer";
    
    // another element but ill put it in the grid (template)
    FrameworkElementFactory myImage = new FrameworkElementFactory(typeof(Image));
    // some bindings and setters
    myImage.SetBinding(Image.SourceProperty, new Binding("ImagePath"));
    myImage.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Center);
    myImage.SetValue(Image.HeightProperty, height);
    myImage.SetValue(Image.WidthProperty, double.NaN);
    myImage.SetValue(Image.SnapsToDevicePixelsProperty, true);
    // add the image to the grid
    grdContainer.AppendChild(myImage);
    
    // set the visual layout of the template to be the grid (main container)
    labelLayout.VisualTree = grdContainer;
    // set the template (line you are looking for mostly)
    lbl.Template = labelLayout;
