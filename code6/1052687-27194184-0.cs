    private void Button_Click(object sender, RoutedEventArgs args)
    {
        ContentDialog dialog = new ContentDialog
        {
            DataContext = new
            {
                RedText = "Red Colour",
                BlueText = "Blue Colour"
            }
        };
 
        dialog.ShowAsync();
    }
