    var uri = new Uri ( "pack://application:,,,/Vibrafit.Demo;component/Resources/myImage.jpg", UriKind.RelativeOrAbsolute ); //unit.Image1Uri;
    var src = new BitmapImage ();
    src.BeginInit();
    src.CacheOption = BitmapCacheOption.OnLoad;
    src.CreateOptions = BitmapCreateOptions.None;
    src.DownloadFailed += delegate {
        Console.WriteLine ( "Failed" );
    };
    
    src.DownloadProgress += delegate {
        Console.WriteLine ( "Progress" );
    };
    
    src.DownloadCompleted += delegate {
        Console.WriteLine ( "Completed" );
    };
    src.UriSource = uri;
    src.EndInit();
