    Rect screenBounds = new Rect(0, 0, Application.Current.Host.Content.ActualWidth, Application.Current.Host.Content.ActualHeight);
    if (VisualTreeHelper.FindElementsInHostCoordinates(screenBounds, myPanorama).Contains(elementToCheck))
        Debug.WriteLine("Element is now visible");
    else
        Debug.WriteLine("Element is no longer visible");
