    private void previousButton_Click(object sender, RoutedEventArgs e)
    {
        tracksImage.Source = new BitmapImage(new Uri(imagePaths[i], UriKind.Relative));
        i = i == 4 ? 0 : i + 1; // Change 4 to the number of images you have + 1. In this example, I assume 5 images.
    }
