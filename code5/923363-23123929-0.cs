    string[] imageArray = new string[] { "url1", url2" }; //This array contains URI strings
    private counter = 0; //This denotes index of array
    private void nextButton_Click(object sender, RoutedEventArgs e)
    {   
        tracksImage.Source = new BitmapImage(new Uri(imageArray[counter], UriKind.Relative));
        counter++;
    }
