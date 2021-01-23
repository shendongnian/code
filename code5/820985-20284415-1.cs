    private void TbStopElement_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if(imageReference != null)
        {
            imageReference.Source = new BitmapImage(new Uri("/YourAppName;component/Resources/YourImage.png", UriKind.Relative));
        }
    }
