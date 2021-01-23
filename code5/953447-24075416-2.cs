    async void button_click(object sender, RoutedEventArgs e)
    {
        // prepare the array
        // ...
        for (var i = 0; i < 100; i++)
        {
            image1.Source = arr[i];
            await Task.Delay(5000);
        }
    }
