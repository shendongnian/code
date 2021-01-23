    if (rootFrame == null)
    {
    // Create a Frame to act as the navigation context and navigate to the first page
    rootFrame = new Frame();
 
    SolidColorBrush color = new SolidColorBrush();
    color.Color = (Windows.UI.ColorHelper.FromArgb(0xFF, 44, 50, 50));
    rootFrame.Background = color;
