    async void someEventHandler(object sender, RoutedEventArgs e)
    {
        await parse();
    }
    async Task parse()
    {
        source.Foreground = new SolidColorBrush(Colors.Black);
        title.Foreground = new SolidColorBrush(Colors.Black);
        tt.Opacity = 0;
        Reader reader = new Reader();
        Article article;
        article = await reader.Read(new Uri(ids));
        tt.Opacity = 0.5;
        source.Foreground = new SolidColorBrush(Colors.White);
        title.Foreground = new SolidColorBrush(Colors.White);
    
        featuredimg.Source = new BitmapImage(
            new Uri(article.FrontImage.ToString(), UriKind.Absolute));
    }
