    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        StreamResourceInfo sri = Application.GetResourceStream(new Uri("VectorImage.xaml", UriKind.Relative));
        if (sri != null)
        {
            using (Stream stream = sri.Stream)
            {
                var logo = XamlReader.Load(stream) as Canvas;
                if (logo != null)
                {
                    this.Grid.Children.Add(logo);
                }
            }
        }
        
    }
