    private TimeSpan time_input = new TimeSpan(0);
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        time_input = media.Position;
        media.Pause();
    }
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        media.Play();
        media.Position = time_input;
    }
