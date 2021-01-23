    private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var element = (FrameworkElement)sender;
        SoundData data = element.DataContext as SoundData;
        _CustomRingtone.Source = new Uri(data.FilePath, UriKind.RelativeOrAbsolute**);
        _CustomRingtone.DisplayName = "Ring";
        _CustomRingtone.Show();
    }
