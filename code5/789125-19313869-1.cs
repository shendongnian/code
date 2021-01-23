    void AddImage(string src)
    {
        BitmapImage bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.UriSource = new Uri(src, UriKind.RelativeOrAbsolute);
        bitmap.EndInit();
        var img = new Image()
        {
            Source = bitmap,
            RenderTransform = new TranslateTransform
        }
        img.ManipulationDelta += OnManipulationDelta;
        // Add additional handlers here..
        CanMap.Children.Add(img);
    }
    void OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
    {
        var transform = (sender as UIElement).RenderTransform as TranslateTransform;
        transform.X += e.DeltaManipulation.Translation.X;
        transform.Y += e.DeltaManipulation.Translation.Y;
     }
