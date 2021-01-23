    ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
    
    Button iconButton = new Button ();
    iconButton.VerticalOptions = LayoutOptions.FillAndExpand;
    iconButton.HorizontalOptions = LayoutOptions.FillAndExpand;
    
    var image = new Image();
    image.Source = imageSource;
    // So it doesn't eat up clicks that should go to the button:
    image.InputTransparent = true;
    // Give it a margin so it doesn't extend to the edge of the grid
    image.Margin = new Thickness(10);
    
    var grid = new Grid();
    // If we don't set a width request, it may stretch horizontally in a stack
    grid.WidthRequest = 48;
    // Add the button first, so it is under the image...
    grid.Children.Add(iconButton);
    // ...then add the image
    grid.Children.Add(image);
