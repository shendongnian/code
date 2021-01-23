    private async void SubmitButton_Click(object sender, RoutedEventArgs e)
    {
        if (LevelUp)
        {
            string imagePath = "Assets/Star/";
            foreach (Image image in GetImages(imagePath))
            {
                ShowImage(image);
                await Task.Delay(timeToWait);
            }
        }
    }
