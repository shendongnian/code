    foreach (var image in images)
    {
        var stars = appSettings[image.Name].ToString();
        if (stars == "0") 
        {
            image.Source = new BitmapImage(new Uri(...));
        }
        ...
    }
